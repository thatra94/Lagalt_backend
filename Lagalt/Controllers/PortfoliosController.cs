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
using Lagalt.DTOs.Portfolio;
using Swashbuckle.AspNetCore.Annotations;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public PortfoliosController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns all portfolios",
            Description = "Returns all portfolios")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<IEnumerable<CommonResponse<PortfolioDto>>>> GetPortfolios()
        {
            CommonResponse<IEnumerable<PortfolioDto>> resp = new CommonResponse<IEnumerable<PortfolioDto>>();
            // Fetch list of model class and map to dto
            var port_models = await _context.Portfolios.ToListAsync();
            List<PortfolioDto> portfolios = _mapper.Map<List<PortfolioDto>>(port_models);
            // Return data
            resp.Data = portfolios; 
            return Ok(resp);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates all values for a portfolio",
            Description = "Updates all values for a portfolio"
            )]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<IActionResult> PutPortfolio(int id, PortfolioDto port)
        {
            // Create response object
            CommonResponse<PortfolioDto> resp = new CommonResponse<PortfolioDto>();

            if (id != port.Id)
            {
                resp.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(resp);
            }
            _context.Entry(_mapper.Map<Portfolio>(port)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PortfolioExists(id))
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

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new portfolio",
            Description = "Creates a new portfolio"
            )]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<PortfolioDto>>> PostPortfolio(PortfolioCreateDto port)
        {
            // Make CommonResponse object to use
            CommonResponse<PortfolioDto> resp = new CommonResponse<PortfolioDto>();
            // Map to model class
            var model = _mapper.Map<Portfolio>(port);
            // Add to db
            _context.Portfolios.Add(model);
            await _context.SaveChangesAsync();
            var l = await _context.Portfolios.Include(l => l.User).FirstOrDefaultAsync(l => l.Id == model.Id);
            resp.Data = _mapper.Map<PortfolioDto>(l);

            return Ok(resp);
        }

        //Get portfolio for user
        [HttpGet("users/{userId}")]
        [SwaggerOperation(
            Summary = "Returns portfolios for a user",
            Description = "Returns portfolios for a user based on id from keycloak"
            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "User not Found")]
        public async Task<ActionResult<CommonResponse<PortfolioDto>>> GetPortfolioforUser(string userId)
        {
            // Make response object
            CommonResponse<IEnumerable<PortfolioDto>> respons = new CommonResponse<IEnumerable<PortfolioDto>>();
            User user = await _context.Users.Include(p => p.Portofolios).Where(u => u.UserId == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                respons.Error = new Error { Status = 404, Message = "A user with that id could not be found." };
                return NotFound(respons);
            }
            foreach (Portfolio portfolio in user.Portofolios)
            {
                portfolio.User = null;
            }
            // Map to dto
            respons.Data = _mapper.Map<List<PortfolioDto>>(user.Portofolios);
            return Ok(respons);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
             Summary = "Deletes a portfolio",
            Description = "Deletes a portfolio"
               )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<PortfolioDto>>> DeletePortfolio(int id)
        {
            // Make response object
            CommonResponse<PortfolioDto> respons = new CommonResponse<PortfolioDto>();

            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                respons.Error = new Error { Status = 404, Message = "An portfolio with that id could not be found." };
                return NotFound(respons);
            }
            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();

            // Map model class to dto 
            respons.Data = _mapper.Map<PortfolioDto>(portfolio);
            return Ok(respons);
        }

        private bool PortfolioExists(int id)
        {
            return _context.Portfolios.Any(e => e.UserId == id);
        }
    }
}
