using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lagalt.DB;
using Lagalt.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Lagalt.ResponseModel;
using Lagalt.DTOs;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public UsersController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<CommonResponse<IEnumerable<UserDto>>>> GetUsers()
        {
            // Create response object
            CommonResponse<IEnumerable<UserDto>> respons = new CommonResponse<IEnumerable<UserDto>>();
            // Fetch list of model class and map to dto
            var modelUser = await _context.Users.ToListAsync();
            List<UserDto> users = _mapper.Map<List<UserDto>>(modelUser);
            // Return the data
            respons.Data = users;
            return Ok(respons);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse<UserDto>>> GetUser(int id)
        {
            // Create response object
            CommonResponse<UserDto> respons = new CommonResponse<UserDto>();
            var userModel = await _context.Users.Include(s => s.Skills).FirstOrDefaultAsync(u => u.Id == id);

            if (userModel == null)
            {
                respons.Error = new Error { Status = 404, Message = "Cannot find an user with that Id" };
                return NotFound(respons);
            }
            // Map 
            respons.Data = _mapper.Map<UserDto>(userModel);
            return Ok(respons);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        //Get skills for user
        [HttpGet("{id}/Skills")]
        public async Task<ActionResult<CommonResponse<SkillDto>>> GetSkillsInUser(int id)
        {
            // Make response object
            CommonResponse<IEnumerable<SkillDto>> respons = new CommonResponse<IEnumerable<SkillDto>>();
            User user = await _context.Users.Include(s => s.Skills).Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                respons.Error = new Error { Status = 404, Message = "An user with that id could not be found." };
                return NotFound(respons);
            }
            foreach (Skill skill in user.Skills)
            {
                skill.Users = null;
            }
            // Map to dto
            respons.Data = _mapper.Map<List<SkillDto>>(user.Skills);
            return Ok(respons);
        }

        //Get skills for user
        [HttpGet("{id}/Projects")]
        public async Task<ActionResult<CommonResponse<ProjectMainDto>>> GetProjectForUser(int id)
        {
            // Make response object
            CommonResponse<IEnumerable<ProjectMainDto>> respons = new CommonResponse<IEnumerable<ProjectMainDto>>();
            User user = await _context.Users.Include(p => p.Projects).Where(u => u.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                respons.Error = new Error { Status = 404, Message = "An user with that id could not be found." };
                return NotFound(respons);
            }
            foreach (Project project in user.Projects)
            {
                project.Users = null;
            }
            // Map to dto
            respons.Data = _mapper.Map<List<ProjectMainDto>>(user.Projects);
            return Ok(respons);
        }
    }
}
