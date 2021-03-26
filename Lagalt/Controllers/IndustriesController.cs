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
using Lagalt.DTOs.Industries;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public IndustriesController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Industries
        [HttpGet]
        public async Task<ActionResult<CommonResponse<IEnumerable<IndustryDto>>>> GetIndustries()
        {
            CommonResponse<IEnumerable<IndustryDto>> response = new CommonResponse<IEnumerable<IndustryDto>>();
            // Map from model to Dto
            var industryModel = await _context.Industries.ToListAsync();
            List<IndustryDto> industries = _mapper.Map<List<IndustryDto>>(industryModel);

            // Return data
            response.Data = industries;
            return Ok(response);
        }

        // GET: api/Industries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommonResponse<IndustryDto>>> GetIndustry(int id)
        {
            CommonResponse<IndustryDto> response = new CommonResponse<IndustryDto>();
            
            var industryModel = await _context.Industries.FindAsync(id);

            if (industryModel == null)
            {
                response.Error = new Error { Status = 404, Message = "Cannot find an industry with that Id" };
                return NotFound(response);
            }
            // Map to Dto
            response.Data = _mapper.Map<IndustryDto>(industryModel);

            return Ok(response);
        }

        // PUT: api/Industries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIndustry(int id, IndustryDto industry)
        {
            CommonResponse<IndustryDto> response = new CommonResponse<IndustryDto>();

            if (id != industry.Id)
            {
                response.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(response);
            }
            // Maps to industry model
            Industry industryModel = _mapper.Map<Industry>(industry);
            _context.Entry(industryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndustryExists(id))
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

        // POST: api/Industries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommonResponse<IndustryDto>>> PostIndustry(IndustryCreateDto industry)
        {
            CommonResponse<IndustryDto> response = new CommonResponse<IndustryDto>();

            if (!ModelState.IsValid)
            {
                response.Error = new Error
                {
                    Status = 400,
                    Message = "The author did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(response);
            }
            // Map to industry model
            Industry industryModel = _mapper.Map<Industry>(industry);

            try
            {
                _context.Industries.Add(industryModel);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                response.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            // Map to industryDto
            response.Data = _mapper.Map<IndustryDto>(industryModel);

            return CreatedAtAction("GetIndustry", new { id = response.Data.Id }, industry);
        }

        // DELETE: api/Industries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonResponse<IndustryDto>>> DeleteIndustry(int id)
        {
            CommonResponse<IndustryDto> response = new CommonResponse<IndustryDto>();

            var industry = await _context.Industries.FindAsync(id);
            if (industry == null)
            {
                response.Error = new Error { Status = 404, Message = "An industry with that id could not be found." };
                return NotFound(response);
            }

            _context.Industries.Remove(industry);
            await _context.SaveChangesAsync();

            // Map to industryDto
            response.Data = _mapper.Map<IndustryDto>(industry);
            return Ok(response);
        }

        private bool IndustryExists(int id)
        {
            return _context.Industries.Any(e => e.Id == id);
        }
    }
}
