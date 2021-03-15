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
using Lagalt.ResponseModel;
using Lagalt.DTOs.UserComments;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public UserCommentsController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/UserComments
        [HttpGet]
        public async Task<ActionResult<CommonResponse<IEnumerable<UserComment>>>> GetUserComments()
        {
            CommonResponse<IEnumerable<UserCommentDto>> response = new CommonResponse<IEnumerable<UserCommentDto>>();
            // Maps from model to Dto
            var commentModel = await _context.UserComments.ToListAsync();
            List<UserCommentDto> comments = _mapper.Map<List<UserCommentDto>>(commentModel);

            // Return data
            response.Data = comments;
            return Ok(response);
        }

        // GET: api/UserComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse<UserCommentDto>>> GetUserComment(int id)
        {
            CommonResponse<UserCommentDto> response = new CommonResponse<UserCommentDto>();

            var commentModel = await _context.UserComments.FindAsync(id);

            if (commentModel == null)
            {
                response.Error = new Error { Status = 404, Message = "Cannot find an user comment with that Id" };
                return NotFound(response);
            }
            // Map to Dto
            response.Data = _mapper.Map<UserCommentDto>(commentModel);

            return Ok(response);
        }

        // PUT: api/UserComments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserComment(int id, UserCommentDto userComment)
        {
            CommonResponse<UserCommentDto> response = new CommonResponse<UserCommentDto>();

            if (id != userComment.Id)
            {
                response.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(response);
            }

            // Maps to model
            UserComment commentModel = _mapper.Map<UserComment>(userComment);
            _context.Entry(commentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserCommentExists(id))
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

        // POST: api/UserComments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommonResponse<UserCommentCreateDto>>> PostUserComment(UserCommentCreateDto userComment)
        {
            CommonResponse<UserCommentDto> response = new CommonResponse<UserCommentDto>();

            if(!ModelState.IsValid)
            {
                response.Error = new Error
                {
                    Status = 400,
                    Message = "Did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(response);
            }
            // Map to model
            UserComment commentModel = _mapper.Map<UserComment>(userComment);

            try
            {
                _context.UserComments.Add(commentModel);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                response.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            // Map to dto
            response.Data = _mapper.Map<UserCommentDto>(commentModel);

            return CreatedAtAction("GetUserComment", new { id = response.Data.Id }, response);
        }

        // DELETE: api/UserComments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonResponse<UserCommentDto>>> DeleteUserComment(int id)
        {
            CommonResponse<UserCommentDto> response = new CommonResponse<UserCommentDto>();

            var userComment = await _context.UserComments.FindAsync(id);

            if (userComment == null)
            {
                response.Error = new Error { Status = 404, Message = "A user comment with that id could not be found." };
                return NotFound(response);
            }

            _context.UserComments.Remove(userComment);
            await _context.SaveChangesAsync();

            // Map to Dto
            response.Data = _mapper.Map<UserCommentDto>(userComment);
            return Ok(response);
        }

        private bool UserCommentExists(int id)
        {
            return _context.UserComments.Any(e => e.Id == id);
        }
    }
}
