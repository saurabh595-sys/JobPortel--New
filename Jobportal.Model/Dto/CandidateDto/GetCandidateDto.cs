using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Model.Dto.CandidateDto
{
   public class GetCandidateDto
    {
       
        public int Id { get; set; }

        public string CandidateName { get; set; }

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public DateTime AppliedAt { get; set; }

    }
}
