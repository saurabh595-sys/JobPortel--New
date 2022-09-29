using System.ComponentModel.DataAnnotations;

namespace Jobportal.Model.Dto.LoginDto
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
