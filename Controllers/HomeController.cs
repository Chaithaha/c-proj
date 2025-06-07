using Microsoft.AspNetCore.Mvc;

namespace GameFinder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
} 