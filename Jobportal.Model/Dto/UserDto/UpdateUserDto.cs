using System.ComponentModel.DataAnnotations;

namespace Jobportal.Model.Dto.UserDto
{
    public  class UpdateUserDto
    {
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email  { get; set; }


    }
}
