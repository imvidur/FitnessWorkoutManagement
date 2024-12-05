using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutMgmnt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {
        private readonly IPaymentService _paymentService = paymentService;

        [HttpGet]
        [Authorize(Policy = "ClientOnly")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPaymentsAsync();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            if (payment == null)
                return NotFound();
            return Ok(payment);
        }

        [HttpPost]
        //[Authorize(Policy = "AdminOnly")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ProcessPayment([FromBody] Payment payment)
        {
            var processedPayment = await _paymentService.ProcessPayment(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { id = processedPayment.Id }, processedPayment);
        }


        [HttpPut("{id}")]
        //[Authorize(Policy = "AdminOnly")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePayment(int id, Payment payment)
        {
            if (id != payment.Id)
                return BadRequest();
            await _paymentService.UpdatePaymentAsync(id, payment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Authorize(Policy = "AdminOnly")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _paymentService.DeletePaymentAsync(id);
            return NoContent();
        }

    }
}
