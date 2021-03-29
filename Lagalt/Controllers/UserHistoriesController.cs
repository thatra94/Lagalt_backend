using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lagalt.DB;
using Lagalt.Models;
using AutoMapper;
using Lagalt.DTOs.UserHistories;
using Lagalt.ResponseModel;
using Lagalt.DTOs.Projects;
using Lagalt.DTOs;
using Lagalt.DTOs.Themes;
using System.Text.RegularExpressions;
using Lagalt.DTOs.Users;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHistoriesController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;
        public UserHistoriesController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<CommonResponse<IEnumerable<UserHistoryDto>>>> GetUserHistories()
        {
            // Create response object
            CommonResponse<IEnumerable<UserHistoryDto>> respons = new CommonResponse<IEnumerable<UserHistoryDto>>();
            // Fetch list of model class and map to dto
            var modelUser = await _context.UserHistories.GroupBy(p => p.ProjectId).ToListAsync();

            List<UserHistoryDto> users = _mapper.Map<List<UserHistoryDto>>(modelUser);
            // Return the data
            respons.Data = users;
            return Ok(respons);
        }
        [HttpGet("/project/{userId}")]
        public async Task<ActionResult<IEnumerable<CommonResponse<ProjectSkillsDto>>>> GetProjectsWithSkills(int userId)
        {
            var uh = await _context.UserHistories.Where(u => u.UserId == userId).
               GroupBy(p => p.ProjectId).Select(g => new UserHistory
               {
                   ProjectId = g.Key,
                   UserId = g.Count()

               }).OrderByDescending(u => u.UserId).FirstOrDefaultAsync();

            var whichP = await _context.Projects.Where(p => p.Id == uh.ProjectId).Include(p => p.IndustryId).FirstAsync();

            var an = await _context.Themes.Include(p => p.Projects.Where(p => p.Id == uh.ProjectId)).FirstAsync();
            
            // Make CommonResponse object to use
            CommonResponse<IEnumerable<ProjectSkillsDto>> response = new CommonResponse<IEnumerable<ProjectSkillsDto>>();
            var projectModel = await _context.Projects.Where(p => p.Id == whichP.Id)
                                                       .Include(p => p.Skills)
                                                      .Include(p => p.Industry)
                                                      .Include(p => p.Themes).FirstOrDefaultAsync();
         
            // Map skills and industry
            List<ProjectSkillsDto> projects = _mapper.Map<List<ProjectSkillsDto>>(projectModel);
            foreach (ProjectSkillsDto project in projects)
            {
                project.Skills = _mapper.Map<List<SkillDto>>(project.Skills);
                project.Themes = _mapper.Map<List<ThemeDto>>(project.Themes);
               project.IndustryName = project.IndustryName;
            }
            // Return data
            response.Data = projects;
            return Ok(response);
        }

        //Get history for user
        [HttpGet("{userId}")]
        public async Task<ActionResult<CommonResponse<UserHistoryDto>>> GetUserHistoryForUser(int userId)
        {

            // Make response object
            CommonResponse<UserHistoryDto> respons = new CommonResponse<UserHistoryDto>();

            /*
            SELECT TOP 1 ProjectId, count(*) as C
FROM UserHistories
group by ProjectId
order by C desc;
            */

            var uh = await _context.UserHistories.Where(u => u.UserId == userId).
                GroupBy(p => p.ProjectId).Select(g => new UserHistory
                {
                    ProjectId = g.Key,
                    UserId = g.Count()
                    
                }).OrderByDescending(u => u.UserId).FirstOrDefaultAsync();

            if (uh == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
                return NotFound(respons);
            }
            // Map to dto
           respons.Data = _mapper.Map<UserHistoryDto>(uh);
            return Ok(respons.Data);
        }

        //post history to user
        [HttpPost]
        public async Task<ActionResult<CommonResponse<UserHistoryDto>>> PostHistory(UserHistoryCreateDto history)
        {
            // Make CommonResponse object to use
            CommonResponse<UserHistoryDto> resp = new CommonResponse<UserHistoryDto>();
            // Map to model class
            var model = _mapper.Map<UserHistory>(history);
            // Add to db
            _context.UserHistories.Add(model);
            await _context.SaveChangesAsync();

            var l = await _context.Portfolios.Include(l => l.User).FirstOrDefaultAsync(l => l.Id == model.Id);
            resp.Data = _mapper.Map<UserHistoryDto>(l);

            return Ok(resp);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<IEnumerable<CommonResponse<ProjectViewDto>>>> GetProjectInProjectView(int id, UserIdDto userId)
        {
            CommonResponse<ProjectViewDto> response = new CommonResponse<ProjectViewDto>();

            var projectModel = await _context.Projects.Include(s => s.Skills)
                                                   .Include(i => i.Industry)
                                                   .Include(t => t.Themes)
                                                   .Include(l => l.Links)
                                                   .FirstOrDefaultAsync(i => i.Id == id);

            if (projectModel == null)
            {
                response.Error = new Error { Status = 404, Message = "Cannot find a project with that Id" };
                return NotFound(response);
            }
            //Map to Dto
            ProjectViewDto project = _mapper.Map<ProjectViewDto>(projectModel);
            project.IndustryName = project.IndustryName;

            UserHistory userHistory = new UserHistory();
            userHistory.ProjectId = id;
            userHistory.TypeHistory = HistoryType.ProjectClickedOn;
            userHistory.UserId = userId.Id;
            _context.UserHistories.Add(userHistory);

        // Save changes to commit to db
          await _context.SaveChangesAsync();

            response.Data = project;

            return Ok(response);
        }
    }
}
