using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Model.Dto.JobDto
{
    public class JobApplyDto
    {
        [Required]
        public int JobId { get; set; }
    }
}
