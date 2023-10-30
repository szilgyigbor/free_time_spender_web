using FreeTimeSpenderWeb.Models;
using FreeTimeSpenderWeb.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    [Route("forum")]
    [ApiController]
    public class ForumController : ControllerBase
    {
        private readonly IForumService _forumService;

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [Route("getposts")]
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var result = await _forumService.GetPosts();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("getpost/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPostById(int id)
        {
            var result = await _forumService.GetPostById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("addpost")]
        [HttpPost]
        public async Task<IActionResult> AddPost([FromBody] PostData post)
        {
            await _forumService.AddPost(post);
            return Ok();
        }

        [Route("addcomment")]
        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentData comment)
        {
            await _forumService.AddComment(comment);
            return Ok();
        }
    }
}
