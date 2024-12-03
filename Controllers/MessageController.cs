using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutMgmnt.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{senderId}/{receiverId}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(int senderId, int receiverId)
        {
            var messages = await _messageService.GetMessagesBetweenUsers(senderId, receiverId);
            return Ok(messages);
        }

        [HttpPost]
        public async Task<ActionResult<Message>> SendMessage(Message message)
        {
            var sentMessage = await _messageService.SendMessage(message);
            return CreatedAtAction(nameof(GetMessages), new { senderId = message.SenderId, receiverId = message.ReceiverId }, sentMessage);
        }
    }
}
