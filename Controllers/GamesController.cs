using Microsoft.AspNetCore.Mvc;
using GameFinder.Models;
using GameFinder.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace GameFinder.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<IActionResult> Index()
        {
            var games = await _gameService.GetAllGamesAsync();
            return View(games);
        }

        public async Task<IActionResult> Details(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null) return NotFound();

            ViewBag.Users = await _gameService.GetAllUsersAsync();
            return View(game);
        }

        public async Task<IActionResult> Create()
        {
            // Load genres and platforms for dropdown
            ViewBag.Genres = await _gameService.GetAllGenresAsync();
            ViewBag.Platforms = await _gameService.GetAllPlatformsAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Game game)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = await _gameService.GetAllGenresAsync();
                ViewBag.Platforms = await _gameService.GetAllPlatformsAsync();
                return View(game);
            }
            await _gameService.AddGameAsync(game);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null) return NotFound();
            
            ViewBag.Genres = await _gameService.GetAllGenresAsync();
            ViewBag.Platforms = await _gameService.GetAllPlatformsAsync();
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Game game)
        {
            if (id != game.Id) return NotFound();
            if (!ModelState.IsValid)
            {
                ViewBag.Genres = await _gameService.GetAllGenresAsync();
                ViewBag.Platforms = await _gameService.GetAllPlatformsAsync();
                return View(game);
            }
            await _gameService.UpdateGameAsync(game);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null) return NotFound();
            return View(game);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GameRecs(int genreId = 0, int platformId = 0)
        {
            IEnumerable<Game> recommendations = null;
            if (genreId == 0 && platformId == 0)
            {
                ViewBag.Error = "Please select both a genre and a platform to get recommendations.";
            }
            else
            {
                recommendations = await _gameService.GetRecommendedGamesAsync(genreId, platformId);
            }
            
            ViewBag.Recommendations = recommendations;
            ViewBag.Genres = await _gameService.GetAllGenresAsync();
            ViewBag.Platforms = await _gameService.GetAllPlatformsAsync();
            return View();
        }
    }
}