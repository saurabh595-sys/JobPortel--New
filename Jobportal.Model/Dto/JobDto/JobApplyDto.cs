using System.ComponentModel.DataAnnotations;

namespace Jobportal.Model.Dto.JobDto
{
    public class JobApplyDto
    {
        [Required]
        public int JobId { get; set; }
    }
}
