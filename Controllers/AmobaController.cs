using FreeTimeSpenderWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeTimeSpenderWeb.Controllers
{
    public class AmobaController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }
    }
}
