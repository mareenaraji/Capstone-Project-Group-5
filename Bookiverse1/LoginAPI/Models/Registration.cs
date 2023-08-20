using System.ComponentModel.DataAnnotations;

namespace LoginAPI.Models
{
    public class Registration
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}
