using Microsoft.AspNetCore.Mvc;
using GameFinder.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace GameFinder.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IGameService _gameService;

        public UsersController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: /Users
        public async Task<IActionResult> Index()
        {
            var users = await _gameService.GetAllUsersAsync();
            return View(users);
        }

        // GET: /Users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _gameService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.UserGames = await _gameService.GetUserGamesAsync(id);
            return View(user);
        }

        // POST: /Users/AddToCollection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCollection(int userId, int gameId)
        {
            await _gameService.AddUserGameAsync(userId, gameId);
            return RedirectToAction("Details", "Games", new { id = gameId });
        }
    }
} 