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

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<CommonResponse<IEnumerable<ProjectDto>>>> GetProjects()
        {
            CommonResponse<IEnumerable<ProjectDto>> response = new CommonResponse<IEnumerable<ProjectDto>>();
            // Maps from model to Dto
            var modelProject = await _context.Projects.ToListAsync();
            List<ProjectDto> projects = _mapper.Map<List<ProjectDto>>(modelProject);
            // Return data
            response.Data = projects;

            return Ok(response);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse<ProjectDto>>> GetProject(int id)
        {
            CommonResponse<ProjectDto> response = new CommonResponse<ProjectDto>();

            var projectModel = await _context.Projects.FindAsync(id);

            if (projectModel == null)
            {
                response.Error = new Error { Status = 404, Message = "Cannot find a project with that Id" };
                return NotFound(response);
            }
            // Maps to Dto
            response.Data = _mapper.Map<ProjectDto>(projectModel);

            return Ok(response);
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, ProjectDto project)
        {
            CommonResponse<ProjectDto> response = new CommonResponse<ProjectDto>();

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


            return CreatedAtAction("GetProject", new { id = response.Data.Id }, response);
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

        [HttpGet("main")]
        public ActionResult<CommonResponse<IQueryable<ProjectMainDto>>> GetProjectsMain()
        {
            CommonResponse<IQueryable<ProjectMainDto>> response = new CommonResponse<IQueryable<ProjectMainDto>>();

            var projects = from p in _context.Projects
                           select new ProjectMainDto()
                           {
                               Id = p.Id,
                               Name = p.Name,
                               ImageUrl = p.ImageUrl,
                               Status = p.Status,
                               IndustryName = p.Industry.Name
                           };

            // Return data
            response.Data = projects;

            return Ok(response);
        }

       
        /*
        [HttpGet("skills")]
        public ActionResult<CommonResponse<IEnumerable<ProjectSkillsDto>>> GetProjectsSkillsMain()
        {
            CommonResponse<IEnumerable<ProjectSkillsDto>> response = new CommonResponse<IEnumerable<ProjectSkillsDto>>();

            var projects = from p in _context.Projects
                           select new ProjectSkillsDto()
                           {
                               Id = p.Id,
                               Name = p.Name,
                               ImageUrl = p.ImageUrl,
                               Status = p.Status,
                               IndustryName = p.Industry.Name,                
                               ProjectSkills = p.Skills
                            };

            // Return data
            response.Data = projects;


            return Ok(response);
        } */


    }
}