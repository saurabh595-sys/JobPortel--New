using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;

namespace JobPortal.Repository.CandidateRepository
{
    public class CandidateRepository:Repository<CandidateMaster>,ICandidateRepository
    {
        public CandidateRepository(Context context):base(context)
        {

        }
    }
}
