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
using Lagalt.DTOs.UserHistories;
using Lagalt.ResponseModel;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHistoriesController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;
        public UserHistoriesController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CommonResponse<IEnumerable<UserHistoryDto>>>> GetUserHistories()
        {
            // Create response object
            CommonResponse<IEnumerable<UserHistoryDto>> respons = new CommonResponse<IEnumerable<UserHistoryDto>>();
            // Fetch list of model class and map to dto
            var modelUser = await _context.UserHistories.Where(t => t.TypeHistory == HistoryType.ProjectClickedOn).ToListAsync();
            List<UserHistoryDto> users = _mapper.Map<List<UserHistoryDto>>(modelUser);
            // Return the data
            respons.Data = users;
            return Ok(respons);
        }
        //Get history for user
        [HttpGet("{userId}")]
        public async Task<ActionResult<CommonResponse<UserHistoryDto>>> GetUserHistoryForUser(int userId)
        {
            // Make response object
            CommonResponse<IEnumerable<UserHistoryDto>> respons = new CommonResponse<IEnumerable<UserHistoryDto>>();
            var uh = await _context.UserHistories.Where(u => u.UserId == userId).ToListAsync();
            if (uh == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
                return NotFound(respons);
            }
            // Map to dto
            respons.Data = _mapper.Map<List<UserHistoryDto>>(uh);
            return Ok(respons);
        }

        //post history to user
        [HttpPost]
        public async Task<ActionResult<CommonResponse<UserHistoryDto>>> PostHistory(UserHistoryCreateDto history)
        {
            // Make CommonResponse object to use
            CommonResponse<UserHistoryDto> resp = new CommonResponse<UserHistoryDto>();
            // Map to model class
            var model = _mapper.Map<UserHistory>(history);
            // Add to db
            _context.UserHistories.Add(model);
            await _context.SaveChangesAsync();

            var l = await _context.Portfolios.Include(l => l.User).FirstOrDefaultAsync(l => l.Id == model.Id);
            resp.Data = _mapper.Map<UserHistoryDto>(l);

            return Ok(resp);
        }

        // DELETE: api/UserHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHistory(int id)
        {
            var userHistory = await _context.UserHistories.FindAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }
            _context.UserHistories.Remove(userHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool UserHistoryExists(int id)
        {
            return _context.UserHistories.Any(e => e.Id == id);
        }
    }
}
