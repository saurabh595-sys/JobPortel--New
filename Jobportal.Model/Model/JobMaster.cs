using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Model.Model
{
    [Table("Job")]
   public class JobMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public bool isActive { get; set; }
    }
}
