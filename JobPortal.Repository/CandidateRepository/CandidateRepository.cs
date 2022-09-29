using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.CandidateRepository
{
    public class CandidateRepository:Repository<CandidateMaster>,ICandidateRepository
    {
        public CandidateRepository(Context context):base(context)
        {

        }
    }
}
