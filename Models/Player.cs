using System.ComponentModel.DataAnnotations;

namespace FootballClub.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Number {  get; set; }
        public string Role { get; set; }
        public int TeamId { get; set; }
    }
}
