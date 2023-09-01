using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    [Route("api/opinion")]
    [ApiController]
    public class OpinionApiController : ControllerBase
    {
        private readonly IOpinionService _messageService;

        public OpinionApiController(IOpinionService messageService)
        {
            _messageService = messageService;
        }

        [Route("getopinions")]
        [HttpGet]
        public async Task<IActionResult> GetOpinions()
        {
            var result = await _messageService.GetOpinions();
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
        [Route("addopinion")]
        [HttpPost]
        public async Task<IActionResult> AddOpinion([FromBody] OpinionData opinion)
        {
            await _messageService.AddOpinion(opinion);
            return Ok();
        }
    }
}
