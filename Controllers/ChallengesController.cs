using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutMgmnt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChallengesController : ControllerBase
    {
        private readonly IChallengeService _challengeService;

        public ChallengesController(IChallengeService challengeService)
        {
            _challengeService = challengeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChallenges()
        {
            var challenges = await _challengeService.GetAllChallenges();
            return Ok(challenges);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChallenge([FromBody] Challenge challenge)
        {
            var createdChallenge = await _challengeService.AddChallenge(challenge);
            return CreatedAtAction(nameof(GetAllChallenges), new { challengeId = createdChallenge.ChallengeId }, createdChallenge);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetChallengesForUser(int userId)
        {
            var challenges = await _challengeService.GetUserChallenges(userId);
            return Ok(challenges);
        }

        [HttpPut("{challengeId}")]
        public async Task<IActionResult> UpdateChallenge(int challengeId, [FromBody] Challenge challenge)
        {
            if (challengeId != challenge.ChallengeId)
                return BadRequest();

            var updatedChallenge = await _challengeService.UpdateChallenge(challenge);
            return Ok(updatedChallenge);
        }
    }

}
