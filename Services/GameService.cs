using GameFinder.Models;
using GameFinder.Data;
using GameFinder.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace GameFinder.Services
{
    public class GameService : IGameService
    {
        private readonly GameFinderContext _context;

        public GameService(GameFinderContext context)
        {
            _context = context;
        }

        // Game operations
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Platform)
                .ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games
                .Include(g => g.Genre)
                .Include(g => g.Platform)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Game>> GetRecommendedGamesAsync(int genreId, int platformId)
        {
            var query = _context.Games.AsQueryable();
            
            if (genreId > 0)
            {
                query = query.Where(g => g.GenreId == genreId);
            }
            
            if (platformId > 0)
            {
                query = query.Where(g => g.PlatformId == platformId);
            }

            return await query
                .Include(g => g.Genre)
                .Include(g => g.Platform)
                .ToListAsync();
        }

        // Genre operations
        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> GetGenreByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task AddGenreAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();
        }

        // Platform operations
        public async Task<IEnumerable<Platform>> GetAllPlatformsAsync()
        {
            return await _context.Platforms.ToListAsync();
        }

        public async Task<Platform> GetPlatformByIdAsync(int id)
        {
            return await _context.Platforms.FindAsync(id);
        }

        public async Task AddPlatformAsync(Platform platform)
        {
            _context.Platforms.Add(platform);
            await _context.SaveChangesAsync();
        }

        // User operations
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        // UserGame operations
        public async Task AddUserGameAsync(int userId, int gameId)
        {
            var userGame = new UserGame
            {
                UserId = userId,
                GameId = gameId,
                DateAdded = DateTime.Now
            };
            
            _context.UserGames.Add(userGame);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveUserGameAsync(int userId, int gameId)
        {
            var userGame = await _context.UserGames
                .FirstOrDefaultAsync(ug => ug.UserId == userId && ug.GameId == gameId);
            
            if (userGame != null)
            {
                _context.UserGames.Remove(userGame);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Game>> GetUserGamesAsync(int userId)
        {
            return await _context.UserGames
                .Where(ug => ug.UserId == userId)
                .Include(ug => ug.Game)
                    .ThenInclude(g => g.Genre)
                .Include(ug => ug.Game)
                    .ThenInclude(g => g.Platform)
                .Select(ug => ug.Game)
                .ToListAsync();
        }
    }
}