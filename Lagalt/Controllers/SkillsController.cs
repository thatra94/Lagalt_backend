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
using Lagalt.DTOs;
using Lagalt.ResponseModel;
using Swashbuckle.AspNetCore.Annotations;

namespace Lagalt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly LagaltContext _context;
        private readonly IMapper _mapper;

        public SkillsController(LagaltContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Skills
        [HttpGet]
        [SwaggerOperation(
            Summary = "Returns all skills",
            Description = "Returns all skill" )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        public async Task<ActionResult<CommonResponse<IEnumerable<SkillDto>>>> GetSkills()
        {
            // Create response object
            CommonResponse<IEnumerable<SkillDto>> respons = new CommonResponse<IEnumerable<SkillDto>>();
            // Fetch list of model class and map to dto
            var skillModel = await _context.Skills.ToListAsync();
            List<SkillDto> skills = _mapper.Map<List<SkillDto>>(skillModel);
            // Return the data
            respons.Data = skills;
            return Ok(respons);
        }

        // GET: api/Skills/5
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get skill by id")]
        [SwaggerResponse(404, "Cannot find a skill with that Id")]
        public async Task<ActionResult<CommonResponse<SkillDto>>> GetSkill(int id)
        {
            // Create response object
            CommonResponse<SkillDto> respons = new CommonResponse<SkillDto>();
            var skillModel = await _context.Skills.FindAsync(id);
            if (skillModel == null)
            {
                respons.Error = new Error { Status = 404, Message = "Cannot find an skill with that Id" };
                return NotFound(respons);
            }
            // Map 
            respons.Data = _mapper.Map<SkillDto>(skillModel);
            return Ok(respons);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Updates all values for a skill",
            Description = "Updates all values for a skill"

            )]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<IActionResult> PutSkill(int id, SkillDto skill)
        {
            // Create response object
            CommonResponse<SkillDto> respons = new CommonResponse<SkillDto>();
            if (id != skill.Id)
            {
                respons.Error = new Error { Status = 400, Message = "There was a mismatch with the provided id and the object." };
                return BadRequest(respons);
            }
            _context.Entry(_mapper.Map<Skill>(skill)).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skill
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new skill",
            Description = "Creates a new skill"

            )]
        [SwaggerResponse(201, "Created")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        public async Task<ActionResult<CommonResponse<SkillDto>>> PostSkill(SkillCreateDto skill)
        {
            // Create response object
            CommonResponse<SkillDto> respons = new CommonResponse<SkillDto>();
            if (!ModelState.IsValid)
            {
                respons.Error = new Error
                {
                    Status = 400,
                    Message = "The skill did not pass validation, ensure it is in the correct format."
                };
                return BadRequest(respons);
            }
            Skill skillModel = _mapper.Map<Skill>(skill);
            // Try catch
            try
            {
                if(_context.Skills.Any(s => s.Name == skillModel.Name))
                {
                    return NoContent();
                }
                else
                {
                    _context.Skills.Add(skillModel);

                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                respons.Error = new Error { Status = 500, Message = e.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, respons);
            }
            // Map to dto 
            respons.Data = _mapper.Map<SkillDto>(skillModel);
            return CreatedAtAction("GetSkill", new { id = respons.Data.Id }, respons);
        }

        // DELETE: api/Skills/5
        [SwaggerOperation(
             Summary = "Deletes a skill",
            Description = "Deletes a skill"
               )]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(405, "Not Allowed")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommonResponse<SkillDto>>> DeleteSkill(int id)
        {
            // Make response object
            CommonResponse<SkillDto> respons = new CommonResponse<SkillDto>();

            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                respons.Error = new Error { Status = 404, Message = "An skill with that id could not be found." };
                return NotFound(respons);
            }
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            // Map model class to dto 
            respons.Data = _mapper.Map<SkillDto>(skill);
            return Ok(respons);
        }

        private bool SkillExists(int id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }
    }
}
