using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lagalt.DB;
using Lagalt.Models;
using Lagalt.ResponseModel;
using Lagalt.DTOs;
using AutoMapper;
using Lagalt.DTOs.Projects;
using Lagalt.DTOs.Industries;
using Lagalt.DTOs.Themes;
using Lagalt.DTOs.UserComments;
using Lagalt.DTOs.Links;
using Swashbuckle.AspNetCore.Annotations;
using Lagalt.DTOs.Users;
using Lagalt.DTOs.UserHistories;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public ProjectsController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns all projects including skills, themes and industry",
            Description = "Returns all projects including skills, themes and industry. Used for banners in main view"

            )]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<IEnumerable<CommonResponse<ProjectSkillsDto>>>> GetProjectsWithSkills()
        {
            // Make CommonResponse object to use
            CommonResponse<IEnumerable<ProjectSkillsDto>> response = new CommonResponse<IEnumerable<ProjectSkillsDto>>();
            var projectModel = await _context.Projects.Include(p => p.Skills)
                                                      .Include(p => p.Industry)
                                                      .Include(p => p.Themes)
                                                      .ToListAsync();

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
    
        // GET: api/Projects/5
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns project based on id. Includes skills, themes and industry",
            Description = "Returns project based on id. Including skills, themes and industry"

            )]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found. Cannot find a project with that Id")]
        public async Task<ActionResult<IEnumerable<CommonResponse<ProjectViewDto>>>> GetProjectInProjectView(int id)
        {
            CommonResponse<ProjectViewDto> response = new CommonResponse<ProjectViewDto>();

            var projectModel = await _context.Projects.Include(s => s.Skills)
                                                   .Include(i => i.Industry)
                                                   .Include(t => t.Themes)
                                                   .Include(l => l.Links)
                                                   .Include(u => u.Users)
                                                   .FirstOrDefaultAsync(i => i.Id == id);

            if (projectModel == null)
            {
                response.Error = new Error { Status = 404, Message = "Cannot find a project with that Id" };
                return NotFound(response);
            }
            //Map to Dto
            ProjectViewDto project = _mapper.Map<ProjectViewDto>(projectModel);
            project.IndustryName = project.IndustryName;
            // Get username to display creator name in response
            var user = await _context.Users.Where(u => u.Id == project.UserId).FirstAsync();
            project.UserName = user.Name;

            response.Data = project;

            return Ok(response);
        }

        // GET: api/Projects/5/comments
        // Get all comments related to a project
        [HttpGet("{id}/comments")]
        [SwaggerOperation(
            Summary = "Returns comments related to a project based on id",
            Description = "Returns comments related to a project based on id"

            )]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found. Cannot find a project with that Id")]
        public async Task<ActionResult<CommonResponse<IEnumerable<ProjectCommentsDto>>>> GetUserComments(int id)
        {
            CommonResponse<IEnumerable<ProjectCommentsDto>> response = new CommonResponse<IEnumerable<ProjectCommentsDto>>();
            // Maps from model to Dto
            var commentModel = await _context.UserComments.Include(uc => uc.User).Where(u => u.ProjectId == id).ToListAsync();
            List<ProjectCommentsDto> comments = _mapper.Map<List<ProjectCommentsDto>>(commentModel);

            foreach (ProjectCommentsDto comment in comments)
            {
                comment.UserName = comment.UserName;
            }

            // Return data
            response.Data = comments;
            return Ok(response);
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates all values for a project",
            Description = "Updates all values for a project"

            )]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<IActionResult> PutProject(int id, ProjectDto projectDto)
        {
            CommonResponse<ProjectUpdateDto> response = new CommonResponse<ProjectUpdateDto>();

            Project project = await _context.Projects.Include(s => s.Skills)
                                               .Include(t => t.Themes)
                                               .Include(l => l.Links)
                                               .FirstOrDefaultAsync(u => u.Id == id);
           // Check if Id exists
            if (id != project.Id)
            {
                response.Error = new Error { Status = 400, Message = "A project with that Id could not be found." };
                return BadRequest(response);
            }
            // Mapping project attributes
            project.Name = projectDto.Name;
            project.Description = projectDto.Description;
            project.ImageUrl = projectDto.ImageUrl;
            project.Status = projectDto.Status;

            // Mapping Skills
            project.Skills.Clear();
            foreach(SkillCreateDto skillName in projectDto.Skills)
            {
                Skill skill = await _context.Skills.Where(s=> s.Name == skillName.Name).FirstOrDefaultAsync();
                if(skill != null)
                {
                    project.Skills.Add(skill);
                }
                else
                {
                    skill = _mapper.Map<Skill>(skillName);
                    project.Skills.Add(skill);
                }
            }

            // Mapping Themes
            project.Themes.Clear();
            foreach (ThemeCreateDto themeName in projectDto.Themes)
            {
                Theme theme = await _context.Themes.Where(t => t.Name == themeName.Name).FirstOrDefaultAsync();
                if (theme != null)
                {
                    project.Themes.Add(theme);
                }
                else
                {
                    theme = _mapper.Map<Theme>(themeName);
                    project.Themes.Add(theme);
                }
            }

            // Mapping Links
            project.Links.Clear();
            foreach (LinkCreateDto linkName in projectDto.Links)
            {
                Link link = await _context.Links.Where(l => l.Name == linkName.Name).FirstOrDefaultAsync();
                if (link != null)
                {
                    project.Links.Add(link);
                }
                else
                {
                    link = _mapper.Map<Link>(linkName);
                    project.Links.Add(link);
                }
            }

            // Maps to project model
            Project projectModel = _mapper.Map<Project>(project);
            _context.Entry(projectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Projects 
        // Post New project
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new project",
            Description = "Creates a new project"

            )]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<ProjectDto>>> PostProject(ProjectCreateDto project)
        {
            CommonResponse<ProjectDto> response = new CommonResponse<ProjectDto>();

            if(!ModelState.IsValid)
            {
                response.Error = new Error
                {
                    Status = 400,
                    Message = "Did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(response);
            }

            Project projectModel = _mapper.Map<Project>(project);

            try
            {
                _context.Projects.Add(projectModel);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                response.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

            // Map to projectDto
            response.Data = _mapper.Map<ProjectDto>(projectModel);

            return CreatedAtAction("GetProjectInProjectView", new { id = response.Data.Id }, response);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a project",
            Description = "Deletes a project"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<ProjectDto>>> DeleteProject(int id)
        {
            CommonResponse<ProjectDto> response = new CommonResponse<ProjectDto>();

            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                response.Error = new Error { Status = 404, Message = "A project with that id could not be found." };
                return NotFound(response);
            }

            // Map to ProjectDto
            response.Data = _mapper.Map<ProjectDto>(project);
            return Ok(response);
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }

        // Get api/Projects/project=foo
        // Project name and more maybe later
        [HttpGet("search/project={searchString}")]
        [SwaggerOperation(
            Summary = "Returns a list of project based on search query",
            Description = "Returns a list of projects in main view based on search query"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<IEnumerable<ProjectSkillsDto>>>> GetProjectsBySearch(string searchString)
        {
            CommonResponse<IEnumerable<ProjectSkillsDto>> response = new CommonResponse<IEnumerable<ProjectSkillsDto>>();
            var projectModel = await _context.Projects.Include(p => p.Skills)
                                                      .Include(p => p.Industry)
                                                      .Include(p => p.Themes)
                                                      .Where(p => p.Name.Contains(searchString) || p.Description.Contains(searchString))
                                                      .ToListAsync();

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

        // Get api/Projects/filter/industry=foo
        // Project name and more maybe later
        [HttpGet("filter/industry={filterString}")]
        [SwaggerOperation(
            Summary = "Filters projects based on industry",
            Description = "Returns a list of projects in main view based on filter"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<IEnumerable<ProjectSkillsDto>>>> GetProjectsByIndustry(string filterString)
        {
            CommonResponse<IEnumerable<ProjectSkillsDto>> response = new CommonResponse<IEnumerable<ProjectSkillsDto>>();
            var projectModel = await _context.Projects.Include(p => p.Skills)
                                                      .Include(p => p.Industry)
                                                      .Include(p => p.Themes)
                                                      .Where(p => p.Industry.Name == filterString)
                                                      .ToListAsync();

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

        [HttpPost("{id}")]
        [SwaggerOperation(
            Summary = "Post project by id including skills, themes and links",
            Description = "Post project by id including skills, themes and links," +
            "Post id of user to store user userhistory type clikcked on"
            )]
        [SwaggerResponse(404, "Cannot find a project with that Id")]
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