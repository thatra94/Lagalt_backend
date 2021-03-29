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
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Get all project applications for a spesific project",
            Description = "Get all project applications with status pending for one project"
            )]
        [SwaggerResponse(404, "A project with that id could not be found")]
        public async Task<ActionResult<CommonResponse<ProjectApplicationShort>>> GetApplicationForProject(int projectId)
        {
            // Make response object
            CommonResponse<IEnumerable<ProjectApplicationShort>> respons = new CommonResponse<IEnumerable<ProjectApplicationShort>>();
            var project = await _context.ProjectApplications.Include(l => l.User).Where(p => p.Project.Id == projectId).
                Where(p => p.Status == "Pending").ToListAsync(); 
            if (project == null)
            {
                respons.Error = new Error { Status = 404, Message = "A project with that id could not be found." };
                return NotFound(respons);
            }
            // Map to dto
            respons.Data = _mapper.Map<List<ProjectApplicationShort>>(project);
            return Ok(respons);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Post project application for a spesific project",
            Description = "Post project application with motivation text for a spesific project, " +
            "status for project is pending upon post"
            )]
        [SwaggerResponse(400, "The post did not pass validation, ensure it is in the correct format")]
        public async Task<ActionResult<CommonResponse<ProjectApplicationDto>>> PostProjectApplication(ProjectApplicationCreateDto post)
        {
            // Make CommonResponse object to use
            CommonResponse<ProjectApplicationDto> resp = new CommonResponse<ProjectApplicationDto>();
            if (!ModelState.IsValid)
            {
                resp.Error = new Error
                {
                    Status = 400,
                    Message = "The post did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(resp);
            }
            var model = _mapper.Map<ProjectApplication>(post);
            model.Status = "Pending";
            // Add to db
            _context.ProjectApplications.Add(model);
            await _context.SaveChangesAsync();

            var l = await _context.ProjectApplications.Include(l => l.User).FirstOrDefaultAsync(l => l.Id == model.Id);
            resp.Data = _mapper.Map<ProjectApplicationDto>(l);

            return Ok(resp);
        }

       [HttpPut]
        [SwaggerOperation(
            Summary = "Update status for one project application, link it to user",
            Description = "Put project to user when application is approved, and set status approved to projectApplications"
            )]
        [SwaggerResponse(400, "The process did not pass validation, ensure it is in the correct format")]
        public async Task<IActionResult> PutProjectToUser(ProjectAppResponsDto post)
        {
            // Make CommonResponse object to use
            CommonResponse<ProjectAppResponsDto> resp = new CommonResponse<ProjectAppResponsDto>();

            Project pro = await _context.Projects.Include(u => u.Users).FirstOrDefaultAsync(p => p.Id == post.ProjectId);
            User newUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == post.UserId);
            ProjectApplication pr =
                await _context.ProjectApplications.Where(p => p.ProjectId == post.ProjectId).FirstOrDefaultAsync();
            pr.Status = "Approved";
    
            pro.Users.Add(newUser);
            // Save changes to commit to db
            await _context.SaveChangesAsync();
            return Ok(resp);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes project application with spesific id"
            )]
        [SwaggerResponse(404, "Could not find a project application with spesific id")]
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
