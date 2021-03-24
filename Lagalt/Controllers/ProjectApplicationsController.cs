using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lagalt.DB;
using Lagalt.Models;
using Lagalt.DTOs.ProjectApplications;
using Lagalt.ResponseModel;
using AutoMapper;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectApplicationsController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public ProjectApplicationsController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ProjectApplications
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommonResponse<ProjectApplicationDto>>>> GetProjectsApplications()
        {
            CommonResponse<IEnumerable<ProjectApplicationDto>> resp = new CommonResponse<IEnumerable<ProjectApplicationDto>>();
            // Fetch list of model class and map to dto
            var models = await _context.ProjectApplications.ToListAsync();
            List<ProjectApplicationDto> projectApp = _mapper.Map<List<ProjectApplicationDto>>(models);
            // Return data
            resp.Data = projectApp;
            return Ok(resp);
        }

        //Get applications for project
        [HttpGet("{projectId}")]
        public async Task<ActionResult<CommonResponse<ProjectApplicationShort>>> GetApplicationForProject(int projectId)
        {
            // Make response object
            CommonResponse<IEnumerable<ProjectApplicationShort>> respons = new CommonResponse<IEnumerable<ProjectApplicationShort>>();
            var project = await _context.ProjectApplications.Include(l => l.User).Where(p => p.Project.Id == projectId).ToListAsync(); 

            if (project == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
                return NotFound(respons);
            }
            // Map to dto
            respons.Data = _mapper.Map<List<ProjectApplicationShort>>(project);
            return Ok(respons);
        }

        [HttpPost]
        public async Task<ActionResult<CommonResponse<ProjectApplicationDto>>> PostProjectApplication(ProjectApplicationCreateDto post)
        {
            // Make CommonResponse object to use
            CommonResponse<ProjectApplicationDto> resp = new CommonResponse<ProjectApplicationDto>();
            // Map to model class
            var model = _mapper.Map<ProjectApplication>(post);
            // Add to db
            _context.ProjectApplications.Add(model);
            await _context.SaveChangesAsync();

            var l = await _context.ProjectApplications.Include(l => l.User).FirstOrDefaultAsync(l => l.Id == model.Id);
            resp.Data = _mapper.Map<ProjectApplicationDto>(l);

            return Ok(resp);
        }


        // DELETE: api/ProjectApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectApplication(int id)
        {
            var projectApplication = await _context.ProjectApplications.FindAsync(id);
            if (projectApplication == null)
            {
                return NotFound();
            }

            _context.ProjectApplications.Remove(projectApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectApplicationExists(int id)
        {
            return _context.ProjectApplications.Any(e => e.Id == id);
        }
    }
}
