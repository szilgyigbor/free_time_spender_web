using FreeTimeSpenderWeb.Sevices;
using Microsoft.AspNetCore.Mvc;


namespace FreeTimeSpenderWeb.Controllers
{
    
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly NewsService _newsService;
        private readonly BotService _botService;
        private readonly WeatherService _weatherService;
        private readonly FlickrService _flickrService;

        public ApiController(NewsService newsService, BotService botService, WeatherService weatherService,
            FlickrService flickrService)
        {
            _newsService = newsService;
            _botService = botService;
            _weatherService = weatherService;
            _flickrService = flickrService;
        }

        
        [Route("api/getnews")]
        [HttpGet]
        public async Task<IActionResult> GetNewsAsync()
        {
            var newsApiKey = Environment.GetEnvironmentVariable("NewsApiKey");
            var result = await _newsService.GetNewsAsync(newsApiKey!);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }


        [Route("api/getbotanswer")]
        [HttpPost]
        public async Task<IActionResult> GetBotAnswerAsync([FromBody] string newMessage)
        {
            var botApiKey = Environment.GetEnvironmentVariable("BotApiKey");
            var result = await _botService.SendPostRequestAsync(botApiKey!, newMessage);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }


        [Route("api/getweather")]
        [HttpPost]
        public async Task<IActionResult> GetWeatherAsync([FromBody] string location)
        {
            var weatherApiKey = Environment.GetEnvironmentVariable("WeatherApiKey");
            var result = await _weatherService.GetWeatherAsync(weatherApiKey!, location);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }


        [Route("api/getimage")]
        [HttpPost]
        public async Task<IActionResult> GetImageAsync([FromBody] string location)
        {
            var flickrApiKey = Environment.GetEnvironmentVariable("FlickrApiKey");
            var result = await _flickrService.GetPictureUrlAsync(flickrApiKey!, location);
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
