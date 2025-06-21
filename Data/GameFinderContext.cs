using Microsoft.EntityFrameworkCore;
using GameFinder.Models;

namespace GameFinder.Data
{
    public class GameFinderContext : DbContext
    {
        public GameFinderContext(DbContextOptions<GameFinderContext> options) : base(options) {}

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<UserGame>()
                .HasKey(ug => new { ug.UserId, ug.GameId });

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGames)
                .HasForeignKey(ug => ug.UserId);

            modelBuilder.Entity<UserGame>()
                .HasOne(ug => ug.Game)
                .WithMany(g => g.UserGames)
                .HasForeignKey(ug => ug.GameId);

            // Configure one-to-many relationships
            modelBuilder.Entity<Game>()
                .HasOne(g => g.Genre)
                .WithMany(gen => gen.Games)
                .HasForeignKey(g => g.GenreId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Platform)
                .WithMany(p => p.Games)
                .HasForeignKey(g => g.PlatformId);
        }
    }
}