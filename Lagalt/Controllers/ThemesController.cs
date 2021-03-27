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
using Lagalt.DTOs.Themes;
using Swashbuckle.AspNetCore.Annotations;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemesController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public ThemesController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Themes
        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns all themes",
            Description = "Returns all themes"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<IEnumerable<ThemeDto>>>> GetThemes()
        {
            CommonResponse<IEnumerable<ThemeDto>> response = new CommonResponse<IEnumerable<ThemeDto>>();
            // Map from model to Dto
            var themeModel = await _context.Themes.ToListAsync();
            List<ThemeDto> themes = _mapper.Map<List<ThemeDto>>(themeModel);

            // Return data
            response.Data = themes;
            return Ok(response);
        }

        // GET: api/Themes/5
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Returns theme based on id",
            Description = "Returns theme based on id"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<ThemeDto>>> GetTheme(int id)
        {
            CommonResponse<ThemeDto> response = new CommonResponse<ThemeDto>();

            var themeModel = await _context.Themes.FindAsync(id);

            if (themeModel == null)
            {
                response.Error = new Error { Status = 404, Message = "Cannot find a theme with that Id" };
                return NotFound(response);
            }
            // Map to dto
            response.Data = _mapper.Map<ThemeDto>(themeModel);

            return Ok(response);
        }

        // PUT: api/Themes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates all values for a theme",
            Description = "Updates all values for a theme"

            )]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<IActionResult> PutTheme(int id, ThemeDto theme)
        {
            CommonResponse<ThemeDto> response = new CommonResponse<ThemeDto>();

            if (id != theme.Id)
            {
                response.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(response);
            }
            // Map to model
            Theme themeModel = _mapper.Map<Theme>(theme);
            _context.Entry(themeModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThemeExists(id))
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

        // POST: api/Themes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new theme",
            Description = "Creates a new theme"

            )]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<ThemeDto>>> PostTheme(ThemeCreateDto theme)
        {
            CommonResponse<ThemeDto> response = new CommonResponse<ThemeDto>();

            if (!ModelState.IsValid)
            {
                response.Error = new Error
                {
                    Status = 400,
                    Message = "Did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(response);
            }

            Theme themeModel = _mapper.Map<Theme>(theme);

            try
            {
                _context.Themes.Add(themeModel);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                response.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
            // Map to dto
            response.Data = _mapper.Map<ThemeDto>(themeModel);

            return CreatedAtAction("GetTheme", new { id = response.Data.Id }, response);
        }

        // DELETE: api/Themes/5
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Deletes a theme",
            Description = "Deletes a theme"

            )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<ThemeDto>>> DeleteTheme(int id)
        {
            CommonResponse<ThemeDto> response = new CommonResponse<ThemeDto>();

            var theme = await _context.Themes.FindAsync(id);
            if (theme == null)
            {
                response.Error = new Error { Status = 404, Message = "A theme with that id could not be found." };
                return NotFound(response);
            }

            _context.Themes.Remove(theme);
            await _context.SaveChangesAsync();

            //Map to dto
            response.Data = _mapper.Map<ThemeDto>(theme);
            return Ok(response);
        }

        private bool ThemeExists(int id)
        {
            return _context.Themes.Any(e => e.Id == id);
        }
    }
}
