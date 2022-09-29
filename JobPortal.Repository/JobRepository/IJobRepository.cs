using Jobportal.Model.Dto.CandidateDto;
using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Inrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.Repository.JobRepository
{
    public interface IJobRepository :IRepository<JobMaster>
    {
        Task<IEnumerable<GetCandidateDto>> GetJobsApplied(int id, Pagination pagination);
        Task<IEnumerable<GetJobDto>> GetJobsAsync(Pagination pagination);
    }
}
