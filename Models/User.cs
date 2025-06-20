using System.ComponentModel.DataAnnotations;

namespace GameFinder.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Navigation property (many-to-many)
        public ICollection<UserGame> UserGames { get; set; } = new List<UserGame>();
    }
} 