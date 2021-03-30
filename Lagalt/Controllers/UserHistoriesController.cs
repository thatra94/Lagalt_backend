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
using Lagalt.DTOs.Projects;
using Lagalt.DTOs;
using Lagalt.DTOs.Themes;
using System.Text.RegularExpressions;
using Lagalt.DTOs.Users;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
            Summary = "Returns all user histories",
            Description = "Returns all user histories" )]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<IEnumerable<UserHistoryDto>>>> GetUserHistories()
        {
            // Create response object
            CommonResponse<IEnumerable<UserHistoryDto>> respons = new CommonResponse<IEnumerable<UserHistoryDto>>();
            // Fetch list of model class and map to dto
            var modelUser = await _context.UserHistories.GroupBy(p => p.ProjectId).ToListAsync();

            List<UserHistoryDto> users = _mapper.Map<List<UserHistoryDto>>(modelUser);
            // Return the data
            respons.Data = users;
            return Ok(respons);
        }
  
        [HttpGet("{userId}")]
        [SwaggerOperation(
            Summary = "Returns user histories by user Id",
            Description = "Returns user histories by user Id")]
        [SwaggerResponse(200, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "User history for user not Found")]
        public async Task<ActionResult<CommonResponse<UserHistoryDto>>> GetUserHistoryForUser(int userId)
        {
            CommonResponse<UserHistoryDto> respons = new CommonResponse<UserHistoryDto>();

            var uh = await _context.UserHistories.Where(u => u.UserId == userId).
                GroupBy(p => p.ProjectId).Select(g => new UserHistory
                {
                    ProjectId = g.Key,
                    UserId = g.Count()
                    
                }).OrderByDescending(u => u.UserId).FirstOrDefaultAsync();
   
            if (uh == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
                return NotFound(respons);
            }
            // Map to dto
           respons.Data = _mapper.Map<UserHistoryDto>(uh);
            return Ok(respons.Data);
        }

        //post history to user
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new user history",
            Description = "Creates a new user history"
            )]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
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
    }
}
