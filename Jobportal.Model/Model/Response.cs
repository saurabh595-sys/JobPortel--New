using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Model.Model
{
   public class Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
