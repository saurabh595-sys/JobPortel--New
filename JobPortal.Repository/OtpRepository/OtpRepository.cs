using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.OtpRepository
{
    public class OtpRepository:Repository<OtpMaster>, IOtpRepository
    {
        public OtpRepository(Context context):base(context)
        {

        }
    }
}
