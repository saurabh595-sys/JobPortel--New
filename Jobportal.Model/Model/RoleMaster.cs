using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
