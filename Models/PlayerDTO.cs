using System.ComponentModel.DataAnnotations;

namespace FootballClub.Models
{
    public class PlayerDTO
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}
