using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    [ApiController]
    public class VisitorApiController : ControllerBase
    {
        private readonly IVisitorManagementService _visitorManagementService;

        public VisitorApiController(IVisitorManagementService visitorManagementService)
        {
            _visitorManagementService = visitorManagementService;
        }

        [HttpGet]
        [Route("api/getvisits")]
        public async Task<IActionResult> GetVisitsAsync()
        {
            var result = await _visitorManagementService.GetVisits();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("api/raisevisitnumber")]
        public async Task<IActionResult> RaiseVisitNumberAsync()
        {
            var result = await _visitorManagementService.RaiseVisitNumber();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
