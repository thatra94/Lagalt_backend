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
        public async Task<ActionResult<IEnumerable<ProjectApplication>>> GetProjectApplication()
        {
            return await _context.ProjectApplication.ToListAsync();
        }

        // GET: api/ProjectApplications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectApplication>> GetProjectApplication(int id)
        {
            var projectApplication = await _context.ProjectApplication.FindAsync(id);

            if (projectApplication == null)
            {
                return NotFound();
            }

            return projectApplication;
        }

        // PUT: api/ProjectApplications/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectApplication(int id, ProjectApplication projectApplication)
        {
            if (id != projectApplication.Id)
            {
                return BadRequest();
            }

            _context.Entry(projectApplication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectApplicationExists(id))
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

        // POST: api/Skill
        [HttpPost]
        public async Task<ActionResult<CommonResponse<ProjectApplicationDto>>> PostProjectApplication(ProjectApplicationUserDto applicationUser)
        {
            // Create response object
            CommonResponse<ProjectApplicationDto> respons = new CommonResponse<ProjectApplicationDto>();
            if (!ModelState.IsValid)
            {
                respons.Error = new Error
                {
                    Status = 400,
                    Message = "The application did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(respons);
            }
            ProjectApplication projectAppModel = _mapper.Map<ProjectApplication>(applicationUser);
            // Try catch
            try
            {
                _context.ProjectApplication.Add(projectAppModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                respons.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, respons);
            }
            // Map to dto 
            respons.Data = _mapper.Map<ProjectApplicationDto>(applicationUser);
            return CreatedAtAction("Get new userapplication", new { id = respons.Data.Id }, respons);
        }


        // DELETE: api/ProjectApplications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectApplication(int id)
        {
            var projectApplication = await _context.ProjectApplication.FindAsync(id);
            if (projectApplication == null)
            {
                return NotFound();
            }

            _context.ProjectApplication.Remove(projectApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectApplicationExists(int id)
        {
            return _context.ProjectApplication.Any(e => e.Id == id);
        }
    }
}
