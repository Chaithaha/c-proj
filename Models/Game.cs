using System.ComponentModel.DataAnnotations;

namespace GameFinder.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Range(0, 10)]
        public double Rating { get; set; }

        // Foreign Keys
        public int GenreId { get; set; }
        public int PlatformId { get; set; }

        // Navigation properties
        public Genre? Genre { get; set; }
        public Platform? Platform { get; set; }
        public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
    }
}