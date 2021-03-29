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
using Lagalt.DTOs.Links;
using Swashbuckle.AspNetCore.Annotations;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinksController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public LinksController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Links
        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns all links",
            Description = "Returns all links"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<IEnumerable<LinkDto>>>> GetLinks()
        {
            CommonResponse<IEnumerable<LinkDto>> response = new CommonResponse<IEnumerable<LinkDto>>();
            // Map from model to Dto
            var linkModel = await _context.Links.ToListAsync();
            List<LinkDto> links = _mapper.Map<List<LinkDto>>(linkModel);

            // Return data
            response.Data = links;
            return Ok(response);
        }

        // GET: api/Links/5
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns link based on id",
            Description = "Returns link based on id"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<LinkDto>>> GetLink(int id)
        {
            CommonResponse<LinkDto> response = new CommonResponse<LinkDto>();

            var linkModel = await _context.Links.FindAsync(id);

            if (linkModel == null)
            {
                response.Error = new Error { Status = 404, Message = "Cannot find a link with that Id" };
                return NotFound(response);
            }
            // Map to dto
            response.Data = _mapper.Map<LinkDto>(linkModel);

            return Ok(response);
        }

        // PUT: api/Links/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates all values for a link",
            Description = "Updates all values for a link"

            )]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<IActionResult> PutLink(int id, LinkDto link)
        {
            CommonResponse<LinkDto> response = new CommonResponse<LinkDto>();

            if (id != link.Id)
            {
                response.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(response);
            }

            // Maps to model
            Link linkModel = _mapper.Map<Link>(link);
            _context.Entry(linkModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinkExists(id))
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

        // POST: api/Links
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new link",
            Description = "Creates a new link"

            )]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<LinkDto>>> PostLink(LinkCreateDto link)
        {
            CommonResponse<LinkDto> response = new CommonResponse<LinkDto>();

            if (!ModelState.IsValid)
            {
                response.Error = new Error
                {
                    Status = 400,
                    Message = "Did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(response);
            }

            Link linkModel = _mapper.Map<Link>(link);

            try
            {
                _context.Links.Add(linkModel);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                response.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            // Map to Dto
            response.Data = _mapper.Map<LinkDto>(linkModel);

            return CreatedAtAction("GetLink", new { id = response.Data.Id }, response);
        }

        // DELETE: api/Links/5
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a link",
            Description = "Deletes a link"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<LinkDto>>> DeleteLink(int id)
        {
            CommonResponse<LinkDto> response = new CommonResponse<LinkDto>();

            var link = await _context.Links.FindAsync(id);
            if (link == null)
            {
                response.Error = new Error { Status = 404, Message = "A link with that id could not be found." };
                return NotFound(response);
            }

            _context.Links.Remove(link);
            await _context.SaveChangesAsync();

            // Map to dto
            response.Data = _mapper.Map<LinkDto>(link);
            return Ok(response);
        }

        private bool LinkExists(int id)
        {
            return _context.Links.Any(e => e.Id == id);
        }
    }
}
