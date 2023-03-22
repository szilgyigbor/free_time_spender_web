using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
