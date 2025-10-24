using Application.BusinessLayer.Services;
using Application.Shared;
using Application.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Application.PresentationLayer.Controllers
{
    [Route("api/medications")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        private readonly MedicationService Service;

        public MedicationsController(MedicationService service)
        {
            Service = service;
        }

        // GET: api/medications
        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 

            var response = await Service.GetAllAsync();

            if (!response.Success) {
                if (response.ErrorMessage == null)
                    return BadRequest(response.DetailedError);
                else
                    return BadRequest(response.ErrorMessage);
            }
            
            return Ok(response.Dto);
        }

        // GET: api/medications/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            if (id <= 0)
                return BadRequest("The medication Id must be higher than 0!");

            var response = await Service.GetByIdAsync(id);

            if (!response.Success)
            {
                if (response.ErrorMessage == null)
                    return BadRequest(response.DetailedError);
                else
                    return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Dto);
        }

        // POST: api/medications
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MedicationCreateDto dto)
        {
            var response = await Service.AddAsync(dto);

            if (!response.Success)
            {
                if (response.ErrorMessage == null)
                    return BadRequest(response.DetailedError);
                else
                    return BadRequest(response.ErrorMessage);
            }

            return CreatedAtAction(nameof(GetById), new { id = response.Dto.MedId }, response.Dto);
        }

        // DELETE: api/medications/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (id <= 0)
                return BadRequest("The medication Id must be higher than 0!");

            var response = await Service.DeleteAsync(id);

            if (!response.Success)
            {
                if (response.ErrorMessage == null)
                    return BadRequest(response.DetailedError);
                else
                    return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Dto);
        }
    }
}
