using GameFinder.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameFinder.Services.Interfaces
{
    public interface IGameService
    {
        // Game operations
        Task<IEnumerable<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(int id);
        Task<IEnumerable<Game>> GetRecommendedGamesAsync(int genreId, int platformId);

        // Genre operations
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre> GetGenreByIdAsync(int id);
        Task AddGenreAsync(Genre genre);

        // Platform operations
        Task<IEnumerable<Platform>> GetAllPlatformsAsync();
        Task<Platform> GetPlatformByIdAsync(int id);
        Task AddPlatformAsync(Platform platform);

        // User operations
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);

        // UserGame operations
        Task AddUserGameAsync(int userId, int gameId);
        Task RemoveUserGameAsync(int userId, int gameId);
        Task<IEnumerable<Game>> GetUserGamesAsync(int userId);
    }
}