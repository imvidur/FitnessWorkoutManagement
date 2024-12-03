using FitnessWorkoutMgmnt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutMgmnt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgressTrackingController : ControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpGet("my-progress")]
        public IActionResult GetMyProgress()
        {
            return Ok("Your progress data.");
        }

        [Authorize(Roles = "Trainer")]
        [HttpPost("update-progress")]
        public IActionResult UpdateClientProgress([FromBody] ProgressTracking progress)
        {
            return Ok("Client progress updated.");
        }
    }
}
