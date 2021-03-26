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
using Lagalt.DTOs.Users;
using Lagalt.DTOs.Projects;

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
        [HttpGet("{userId}")]
        public async Task<ActionResult<CommonResponse<UserDto>>> GetUser(string userId)
        {
            // Create response object
            CommonResponse<UserDto> respons = new CommonResponse<UserDto>();
            var userModel = await _context.Users.Include(s => s.Skills).FirstOrDefaultAsync(u => u.UserId == userId);

            if (userModel == null)
            {
                respons.Error = new Error { Status = 404, Message = "Cannot find a user with that Id" };
                return NotFound(respons);
            }
            // Map 
            respons.Data = _mapper.Map<UserDto>(userModel);
            return Ok(respons);
        }
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<CommonResponse<UserDto>>> PostUser(UserCreateDto user)
        {
            // Create response object
            CommonResponse<UserDto> respons = new CommonResponse<UserDto>();
            if (!ModelState.IsValid)
            {
                respons.Error = new Error
                {
                    Status = 400,
                    Message = "The user did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(respons);
            }
            User userModel = _mapper.Map<User>(user);
            // Try catch
            try
            {
                _context.Users.Add(userModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                respons.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, respons);
            }
            // Map to dto 
            respons.Data = _mapper.Map<UserDto>(userModel);
            return CreatedAtAction("GetUser", new { userId = respons.Data.UserId }, respons);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonResponse<UserDto>>> DeleteUser(int id)
        {
            CommonResponse<UserDto> respons = new();

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            respons.Data = _mapper.Map<UserDto>(user);

            return Ok(respons);
        }
        private bool UserExists(string userId)
        {
            return _context.Users.Any(e => e.UserId == userId);
        }

        //Get skills for user
        [HttpGet("{userId}/Skills")]
        public async Task<ActionResult<CommonResponse<SkillDto>>> GetSkillsInUser(string userId)
        {
            // Make response object
            CommonResponse<IEnumerable<SkillDto>> respons = new CommonResponse<IEnumerable<SkillDto>>();
            User user = await _context.Users.Include(s => s.Skills).Where(u => u.UserId == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
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
        [HttpGet("{userId}/Projects")]
        public async Task<ActionResult<CommonResponse<ProjectSkillsDto>>> GetProjectForUser(string userId)
        {
            // Make response object
            CommonResponse<IEnumerable<ProjectSkillsDto>> respons = new CommonResponse<IEnumerable<ProjectSkillsDto>>();
            var projectModel = await _context.Projects.Include(p => p.Skills)
                                                  .Include(p => p.Industry)
                                                  .Include(p => p.Themes)
                                                  .ToListAsync();

            User user = await _context.Users.Include(p => p.Projects).Where(u => u.UserId == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
                return NotFound(respons);
            }
            foreach (Project project in user.Projects)
            {
                project.Users = null;
            }
            // Map to dto
            respons.Data = _mapper.Map<List<ProjectSkillsDto>>(user.Projects);
            return Ok(respons);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> PutUserWithSkills(string userId, UserUpdateDto user)
        {
            // Create response object
            CommonResponse<UserUpdateDto> respons = new CommonResponse<UserUpdateDto>();
            User userModel = await _context.Users.Include(s => s.Skills).FirstOrDefaultAsync(u => u.UserId == userId);

            if (userId != user.UserId)
            {
                respons.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(respons);
            }
            userModel.Description = user.Description;
            userModel.ImageUrl = user.ImageUrl;

            foreach (SkillCreateDto skillName in user.Skills)
            {
                Skill skill = await _context.Skills.Where(s => s.Name == skillName.Name).FirstOrDefaultAsync();
                if (skill == null)
                {
                    skill = _mapper.Map<Skill>(skillName);
                    userModel.Skills.Add(skill);
                }
                 userModel.Skills.Add(skill);
            }
            // Save changes to commit to db
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/User/5
        [HttpGet("api/{user}/userProfil/{userId}")]
        public async Task<ActionResult<CommonResponse<UserProfilDto>>> GetUserProfil(int user, string userId)
        {
            // Create response object
            CommonResponse<UserProfilDto> respons = new CommonResponse<UserProfilDto>();
            var projectModel = await _context.Projects.Include(p => p.Skills)
                                      .Include(p => p.Industry)
                                      .Include(p => p.Themes)
                                      .ToListAsync();

            var userModel = await _context.Users.
                                    Include(p => p.Projects).
                                    Include(p => p.Portofolios).
                                    Where(u => u.UserId == userId).FirstOrDefaultAsync();

            foreach (Project project in userModel.Projects)
            {
                User userAdmin = await _context.Users.Where(u => u.Id == user).FirstOrDefaultAsync();

                if (project.UserId == userAdmin.Id)
                {
                    userModel = await _context.Users.Include(s => s.Skills).FirstOrDefaultAsync();
                    respons.Data = _mapper.Map<UserProfilDto>(userModel);
                } else
                {
                    respons.Data = _mapper.Map<UserProfilDto>(userModel);
                }
            }
            if (userModel == null)
            {
                respons.Error = new Error { Status = 404, Message = "Cannot find a user with that Id" };
                return NotFound(respons);
            }
            // Map 
            return Ok(respons);
        }
    }
}