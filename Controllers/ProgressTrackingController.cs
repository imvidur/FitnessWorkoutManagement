using FitnessWorkoutMgmnt.Data;
using FitnessWorkoutMgmnt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutMgmnt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressTrackingController : ControllerBase
    {
        private readonly FitnessDbContext _context;


        public ProgressTrackingController(FitnessDbContext context)
        {
            _context = context;
        }

        // GET: api/progresstracking/my-progress
        [HttpGet("my-progress")]
        public async Task<IActionResult> GetMyProgress(int userId)
        {
            var progress = await _context.ProgressTrackings
                                         .FirstOrDefaultAsync(p => p.UserId == userId);

            if (progress == null)
            {
                return NotFound("No progress data found.");
            }

            return Ok(progress);
        }

        [HttpPost("update-progress")]
        public async Task<IActionResult> UpdateClientProgress([FromBody] ProgressTracking progress)
        {
            _context.ProgressTrackings.Add(progress);
            await _context.SaveChangesAsync();

            return Ok(progress);
        }
    }
}
