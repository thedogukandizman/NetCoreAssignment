using System.ComponentModel.DataAnnotations;

namespace NetCoreAssignment.Service.Contracts.Dtos.Users
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
