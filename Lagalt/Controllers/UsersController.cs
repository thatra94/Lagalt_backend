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
using Swashbuckle.AspNetCore.Annotations;
using Lagalt.DTOs.Themes;

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
       [SwaggerOperation(
            Summary = "Returns all users",
            Description = "Returns all users")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
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

        [HttpGet("{userId}")]
        [SwaggerOperation(
            Summary = "Returns user based on id from keycloak",
            Description = "Returns user based on id from keycloak"
            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
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
        [SwaggerOperation(
            Summary = "Creates a new user",
            Description = "Creates a new user"
            )]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
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
        [SwaggerOperation(
             Summary = "Deletes a user",
            Description = "Deletes a user by id"
               )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
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

        [HttpGet("{userId}/Skills")]
        [SwaggerOperation(
            Summary = "Returns skills for a user",
            Description = "Returns skills for a user based on id from keycloak"
            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "User not Found")]
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

        [HttpGet("{userId}/Projects")]
        [SwaggerOperation(
            Summary = "Returns all project for a user",
            Description = "Returns projects for a user based on id from keycloak"
            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "User not Found")]
        public async Task<ActionResult<CommonResponse<ProjectSkillsDto>>> GetProjectForUser(string userId)
        {
            // Make response object
            CommonResponse<IEnumerable<ProjectSkillsDto>> respons = new CommonResponse<IEnumerable<ProjectSkillsDto>>();
            var user = await _context.Users.Include(p => p.Projects).ThenInclude(p => p.Themes).
                            Include(p => p.Projects).ThenInclude(p => p.Skills).
                            Include(p => p.Projects).ThenInclude(p => p.Industry).
                            Where(u => u.UserId == userId).FirstOrDefaultAsync();

            var projectModel = await _context.Projects.Where(p => p.UserId == user.Id)
                                          .Include(p => p.Skills)
                                         .Include(p => p.Industry)
                                         .Include(p => p.Themes)
                                         .ToListAsync();

            if (user == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
                return NotFound(respons);
            }
            foreach (Project project in projectModel)
            {
                user.Projects.Add(project);
            }
            // Map to dto
            respons.Data = _mapper.Map<List<ProjectSkillsDto>>(user.Projects);
            return Ok(respons);
        }

        [HttpPut("{userId}")]
        [SwaggerOperation(
            Summary = "Put user: update description, hidden mode and skills for user")]
        [SwaggerResponse(404, "Cannot find an user with that Id")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
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
            userModel.Hidden = user.Hidden;

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
        
        [HttpPost("{user}")]
        [SwaggerOperation(
            Summary = "Post user profil by id including skills, projects and portfolio",
            Description = "Post user profil by id including skills, projects and portfolio," +
            "Post id of user checkout out userId's userprofil. Limit view based on user is hidden" +
            "and check if user is admin or not on any project this userporfil contributes to"
            )]
        [SwaggerResponse(404, "Cannot find a user with that Id")]
        public async Task<ActionResult<CommonResponse<UserProfilDto>>> GetUserProfil(int user, UserIdDto userId)
        {
            // Create response object
            CommonResponse<UserProfilDto> respons = new CommonResponse<UserProfilDto>();
            var projectModel = await _context.Projects.Include(p => p.Skills)
                                      .Include(p => p.Industry)
                                      .Include(p => p.Themes)
                                      .ToListAsync();

            var userModel = await _context.Users.
                                    Include(p => p.Projects).
                                    Include(p => p.Portofolios)
                                    .FirstOrDefaultAsync(u => u.Id == user);
            if(userModel.Hidden == false)
            {
                userModel = await _context.Users.Include(s => s.Skills).FirstOrDefaultAsync(u => u.Id == user);
                respons.Data = _mapper.Map<UserProfilDto>(userModel);
            }
    
            else if  (userModel.Hidden == true)
            {
                respons.Data = _mapper.Map<UserProfilDto>(userModel);

                foreach (Project project in userModel.Projects)
                {
                    User userAdmin = await _context.Users.Where(u => u.Id == userId.Id).FirstOrDefaultAsync();

                    if (project.UserId == userAdmin.Id)
                    {
                        userModel = await _context.Users.Include(s => s.Skills).FirstOrDefaultAsync(u => u.Id == user);
                        respons.Data = _mapper.Map<UserProfilDto>(userModel);
                    }
                    else
                    {
                        respons.Data = _mapper.Map<UserProfilDto>(userModel);
                    }
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