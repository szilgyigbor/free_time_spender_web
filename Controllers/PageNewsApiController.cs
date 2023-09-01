using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FreeTimeSpenderWeb.Controllers
{
    [Route("api/pagenews")]
    [ApiController]
    public class PageNewsApiController : ControllerBase
    {
        private readonly IPageNewsService _pageNewsService;

        public PageNewsApiController(IPageNewsService pageNewsService)
        {
            _pageNewsService = pageNewsService;
        }

        [Route("getpagenews")]
        [HttpGet]
        public async Task<IActionResult> GetPageNews()
        {
            var result = await _pageNewsService.GetPageNews();
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
        [Route("addpagenews")]
        [HttpPost]
        public async Task<IActionResult> AddPageNews([FromBody] PageNewsData pageNews)
        {
            await _pageNewsService.AddPageNews(pageNews);
            return Ok();
        }
    }
}
