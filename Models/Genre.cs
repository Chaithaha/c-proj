using System.ComponentModel.DataAnnotations;

namespace GameFinder.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        // Navigation property (one-to-many)
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
} 