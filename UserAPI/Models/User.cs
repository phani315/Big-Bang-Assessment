using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        public byte[]? Password { get; set; }
        public byte[]? HashKey { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$")]

        public string? PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 99)]

        public int Age { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]

        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
