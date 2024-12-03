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
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetAllSubscriptions()
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync();
            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscriptionById(int id)
        {
            var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);
            if (subscription == null)
                return NotFound();
            return Ok(subscription);
        }

        [HttpPost]
        public async Task<ActionResult<Subscription>> CreateSubscription(Subscription subscription)
        {
            var createdSubscription = await _subscriptionService.CreateSubscriptionAsync(subscription);
            return CreatedAtAction(nameof(GetSubscriptionById), new { id = createdSubscription.SubscriptionId }, createdSubscription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(int id, Subscription subscription)
        {
            if (id != subscription.SubscriptionId)
                return BadRequest();
            await _subscriptionService.UpdateSubscriptionAsync(id, subscription);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            await _subscriptionService.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}
