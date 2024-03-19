using System.ComponentModel.DataAnnotations;

namespace api.Dto.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}