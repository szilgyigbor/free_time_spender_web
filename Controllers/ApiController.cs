using FreeTimeSpenderWeb.Sevices;
using FreeTimeSpenderWeb.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;


namespace FreeTimeSpenderWeb.Controllers
{
    
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly NewsService _newsService;
        private readonly BotService _botService;
        private readonly WeatherService _weatherService;

        public ApiController(IConfiguration configuration, NewsService newsService, BotService botService, WeatherService weatherService)
        {
            _configuration = configuration;
            _newsService = newsService;
            _botService = botService;
            _weatherService = weatherService;
        }


        
        [Route("api/getnews")]
        [HttpGet]
        public async Task<IActionResult> GetNewsAsync()
        {
            var newsApiKey = _configuration["NewsApiKey"];
            var result = await _newsService.GetNewsAsync(newsApiKey);
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
            var botApiKey = _configuration["BotApiKey"];
            var result = await _botService.SendPostRequestAsync(botApiKey, newMessage);
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
            var weatherApiKey = _configuration["WeatherApiKey"];
            var result = await _weatherService.GetWeatherAsync(weatherApiKey, location);
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
