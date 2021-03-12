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

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

<<<<<<< HEAD:Lagalt/Controllers/UserController.cs
        public UsersController(LagaltContext context, IMapper mapper)
=======
        public ProjectsController(LegaltContext context)
>>>>>>> mmj-projects:Lagalt/Controllers/ProjectsController.cs
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Projects
        [HttpGet]
<<<<<<< HEAD:Lagalt/Controllers/UserController.cs
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
=======
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
>>>>>>> mmj-projects:Lagalt/Controllers/ProjectsController.cs
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
<<<<<<< HEAD:Lagalt/Controllers/UserController.cs
            var user = await _context.Users.FindAsync(id);
=======
            var project = await _context.Projects.FindAsync(id);
>>>>>>> mmj-projects:Lagalt/Controllers/ProjectsController.cs

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, Project project)
        {
            if (id != project.Id)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

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
        public async Task<ActionResult<Project>> PostProject(Project project)
        {
<<<<<<< HEAD:Lagalt/Controllers/UserController.cs
            _context.Users.Add(user);
=======
            _context.Projects.Add(project);
>>>>>>> mmj-projects:Lagalt/Controllers/ProjectsController.cs
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.Id }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
<<<<<<< HEAD:Lagalt/Controllers/UserController.cs
            var user = await _context.Users.FindAsync(id);
            if (user == null)
=======
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
>>>>>>> mmj-projects:Lagalt/Controllers/ProjectsController.cs
            {
                return NotFound();
            }

<<<<<<< HEAD:Lagalt/Controllers/UserController.cs
            _context.Users.Remove(user);
=======
            _context.Projects.Remove(project);
>>>>>>> mmj-projects:Lagalt/Controllers/ProjectsController.cs
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectExists(int id)
        {
<<<<<<< HEAD:Lagalt/Controllers/UserController.cs
            return _context.Users.Any(e => e.Id == id);
=======
            return _context.Projects.Any(e => e.Id == id);
>>>>>>> mmj-projects:Lagalt/Controllers/ProjectsController.cs
        }
    }
}
