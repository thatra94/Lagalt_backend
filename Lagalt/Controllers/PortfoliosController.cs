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

        // GET: api/Portfolios
        [HttpGet]
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

        // GET: api/¨Portfolios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse<PortfolioDto>>> GetPortfolio(int id)
        {
            // Create response object
            CommonResponse<PortfolioDto> respons = new CommonResponse<PortfolioDto>();
            var portfolio = await _context.Portfolios.FindAsync(id);
            if (portfolio == null)
            {
                respons.Error = new Error { Status = 404, Message = "Cannot find a portfolio with that Id" };
                return NotFound(respons);
            }
            // Map 
            respons.Data = _mapper.Map<PortfolioDto>(portfolio);
            return Ok(respons);
        }
        [HttpPut("{id}")]
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

        // DELETE: api/Skills/5
        [HttpDelete("{id}")]
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
