using System.ComponentModel.DataAnnotations;

namespace Jobportal.Model.Dto.RoleDto
{
    public class AddRoleDto
    {
        [Required]
        public string Role { get; set; }
    }
}
