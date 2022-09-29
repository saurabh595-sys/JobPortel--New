using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Model.Dto.UserDto
{
   public class AddUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Minimum length should be 8 characters,1 capital letter,1 special character,1 numeric character")]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
