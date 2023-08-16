using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    [ApiController]
    public class ResultApiController : ControllerBase
    {
        private readonly ISortingGameService _sortingGameService;

        public ResultApiController(ISortingGameService sortingGameService)
        {
            _sortingGameService = sortingGameService;
        }

        [Route("api/getsortingresults")]
        [HttpGet]
        public async Task<IActionResult> GetResults()
        {
            var result = await _sortingGameService.GetResults();
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
        [Route("api/addsortingresult")]
        [HttpPost]
        public async Task<IActionResult> AddResult([FromBody] SortingGameData sortingGameData)
        {
            await _sortingGameService.AddResult(sortingGameData);
            return Ok();
        }
    }
}
