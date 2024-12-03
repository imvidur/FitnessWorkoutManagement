using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutMgmnt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FitnessClassController : ControllerBase
    {
        private readonly IFitnessClassService _fitnessClassService;

        public FitnessClassController(IFitnessClassService fitnessClassService)
        {
            _fitnessClassService = fitnessClassService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessClass>>> GetAllFitnessClasses()
        {
            var fitnessClasses = await _fitnessClassService.GetAllFitnessClassesAsync();
            return Ok(fitnessClasses);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessClass>> GetFitnessClassById(int id)
        {
            var fitnessClass = await _fitnessClassService.GetFitnessClassByIdAsync(id);
            if (fitnessClass == null)
                return NotFound();
            return Ok(fitnessClass);
        }

        [HttpPost]
        public async Task<ActionResult<FitnessClass>> CreateFitnessClass(FitnessClass fitnessClass)
        {
            var createdFitnessClass = await _fitnessClassService.CreateFitnessClassAsync(fitnessClass);
            return CreatedAtAction(nameof(GetFitnessClassById), new { id = createdFitnessClass.ClassId }, createdFitnessClass);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFitnessClass(int id, FitnessClass fitnessClass)
        {
            if (id != fitnessClass.ClassId)
                return BadRequest();
            await _fitnessClassService.UpdateFitnessClassAsync(id, fitnessClass);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFitnessClass(int id)
        {
            await _fitnessClassService.DeleteFitnessClassAsync(id);
            return NoContent();
        }
    }
}
