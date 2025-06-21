using GameFinder.Models;

namespace GameFinder.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GameFinderContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if Genres table has data
            if (context.Genres.Any())
            {
                return; // Database has been seeded
            }

            // Seed Genres
            var genres = new Genre[]
            {
                new Genre { Name = "Action" },
                new Genre { Name = "Adventure" },
                new Genre { Name = "RPG" },
                new Genre { Name = "Strategy" },
                new Genre { Name = "Sports" },
                new Genre { Name = "Racing" },
                new Genre { Name = "Puzzle" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Simulation" },
                new Genre { Name = "Fighting" }
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();

            // Seed Platforms
            var platforms = new Platform[]
            {
                new Platform { Name = "PC" },
                new Platform { Name = "PlayStation" },
                new Platform { Name = "Xbox" },
                new Platform { Name = "Nintendo" },
                new Platform { Name = "Mobile" },
                new Platform { Name = "VR" }
            };

            context.Platforms.AddRange(platforms);
            context.SaveChanges();

            // Seed Users
            var users = new User[]
            {
                new User { Username = "john_doe", Email = "john@example.com" },
                new User { Username = "jane_smith", Email = "jane@example.com" },
                new User { Username = "mike_wilson", Email = "mike@example.com" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
} 