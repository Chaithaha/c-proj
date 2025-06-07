using Microsoft.EntityFrameworkCore;
using GameFinder.Models;

namespace GameFinder.Data
{
    public class GameFinderContext : DbContext
    {
        public GameFinderContext(DbContextOptions<GameFinderContext> options) : base(options) {}

        public DbSet<Game> Games { get; set; }
    }
}