using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Model.Dto.UserDto
{
   public class GetUserDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
      
     
        public string Email { get; set; }

      
        public DateTime CreatedDate { get; set; }

    
        public bool IsActive { get; set; }

    }
}
