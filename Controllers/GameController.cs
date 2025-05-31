using Microsoft.AspNetCore.Mvc;
using GameFinder.Models;

namespace GameFinder.Controllers
{
    public class GameController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(GameSearchModel model)
        {
            return RedirectToAction("Results", model);
        }

        public IActionResult Results(GameSearchModel model)
        {
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}