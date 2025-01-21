using System.ComponentModel.DataAnnotations;

namespace DailyJokesApp.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
