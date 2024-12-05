using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FitnessWorkoutMgmnt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class WorkoutController : ControllerBase
    {
        private readonly FitnessDbContext _context;

        public WorkoutController(FitnessDbContext context)
        {
            _context = context;
        }

        // POST /api/WorkoutPlan
        [HttpPost("WorkoutPlan")]
        //[Authorize(Roles ="Trainer")]
        public async Task<IActionResult> CreateWorkoutPlan([FromBody] WorkoutPlan plan)
        {
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.WorkoutPlans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkoutPlan), new { planId = plan.PlanId }, plan);
        }


        // GET /api/WorkoutPlan/{planId}
        [HttpGet("WorkoutPlan/{planId}")]
        public async Task<IActionResult> GetWorkoutPlan(int planId)
        {
            var plan = await _context.WorkoutPlans.FindAsync(planId);

            if (plan == null)
                return NotFound($"Workout plan with ID {planId} not found.");

            return Ok(plan);
        }

        // PUT /api/WorkoutPlan/{planId}
        [HttpPut("WorkoutPlan/{planId}")]
        //[Authorize(Roles = "Trainer")]
        public async Task<IActionResult> UpdateWorkoutPlan(int planId, [FromBody] WorkoutPlan updatedPlan)
        {
            if (planId != updatedPlan.PlanId)
                return BadRequest("Plan ID mismatch.");

            var existingPlan = await _context.WorkoutPlans.FindAsync(planId);
            if (existingPlan == null)
                return NotFound($"Workout plan with ID {planId} not found.");

            existingPlan.Name = updatedPlan.Name;
            existingPlan.Description = updatedPlan.Description;

            _context.Entry(existingPlan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE /api/WorkoutPlan/{planId}
        [HttpDelete("WorkoutPlan/{planId}")]
        //[Authorize(Roles = "Trainer")]
        public async Task<IActionResult> DeleteWorkoutPlan(int planId)
        {
            var plan = await _context.WorkoutPlans.FindAsync(planId);
            if (plan == null)
                return NotFound($"Workout plan with ID {planId} not found.");

            _context.WorkoutPlans.Remove(plan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
