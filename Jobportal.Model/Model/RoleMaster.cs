using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jobportal.Model.Model
{
    [Table("Role")]
    public class RoleMaster
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public string Role { get; set; }
    }
}
