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
                // project.Industry = _mapper.Map<IndustryDto>(project.Industry);
                project.IndustryName = project.IndustryName;
            }
            // Return data
            response.Data = projects;
            return Ok(response);
        }

        // GET: api/Projects/5/comments
        // Get all comments related to a project
        [HttpGet("{id}/comments")]
        public async Task<ActionResult<IEnumerable<CommonResponse<ProjectCommentsDto>>>> GetProjectComments(int id)
        {
            CommonResponse<IEnumerable<ProjectCommentsDto>> response = new CommonResponse<IEnumerable<ProjectCommentsDto>>();

            var project = await _context.Projects.Include(p => p.UserComments).
                                                      Include(p => p.Users).
                                                      Where(p => p.Id == id).FirstOrDefaultAsync();
            if (project == null)
            {
                response.Error = new Error { Status = 404, Message = "A project with that id could not be found." };
                return NotFound(response);
            }

            // Map to dto
            List<ProjectCommentsDto> comments = _mapper.Map<List<ProjectCommentsDto>>(project.UserComments);
            
            foreach(ProjectCommentsDto comment in comments)
            { 
                comment.UserName = comment.UserName;
            } 

            response.Data = comments;
            return Ok(response);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CommonResponse<ProjectViewDto>>>> GetProjectInProjectView(int id)
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

            response.Data = project;

            return Ok(response);
        } 
     
        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectUpdateDto project)
        {
            CommonResponse<ProjectUpdateDto> response = new CommonResponse<ProjectUpdateDto>();

            if (id != project.Id)
            {
                response.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(response);
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
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
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



    }
}