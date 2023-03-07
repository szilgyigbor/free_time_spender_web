using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
