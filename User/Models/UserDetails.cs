using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class UserDetails
    {
        [Key]
        public string Username { get; set; }

        public byte[]? Password { get; set; }

        public byte[]? HashKey { get; set; }

        public string? PhoneNumber { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
        public string Role { get; set; }
    }
}
