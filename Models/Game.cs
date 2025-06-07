using System.ComponentModel.DataAnnotations;

namespace GameFinder.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Platform { get; set; }

        [Range(0, 10)]
        public double Rating { get; set; }
    }
}