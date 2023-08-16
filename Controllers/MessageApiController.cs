using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    [Route("api/messages")]
    [ApiController]
    public class MessageApiController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageApiController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [Route("getmessages")]
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            var result = await _messageService.GetMessages();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [Route("addmessage")]
        [HttpPost]
        public async Task<IActionResult> AddMessage([FromBody] MessageData message)
        {
            await _messageService.AddMessage(message);
            return Ok();
        }
    }
}
