using System.ComponentModel.DataAnnotations;

namespace GameFinder.Models
{
    public class UserGame
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        
        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        // Navigation properties
        public User? User { get; set; }
        public Game? Game { get; set; }
    }
} 