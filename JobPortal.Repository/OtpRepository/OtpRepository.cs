using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;

namespace JobPortal.Repository.OtpRepository
{
    public class OtpRepository:Repository<OtpMaster>, IOtpRepository
    {
        public OtpRepository(Context context):base(context)
        {

        }
    }
}
