

using System.ComponentModel.DataAnnotations;


namespace DailyJokesApp.Models
{
    public class Jokes
    {
        [Key]
        public int JokeId { get; set; }
        [Required]
        public string Question { get; set; }
        public string Username { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        [MaxLength(50)]
        public string DateCreated { get; set; }
        public int NumberOfLikes { get; set; }
    }
}
