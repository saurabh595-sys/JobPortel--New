using Jobportal.Model.Model;
using Jobportal.Model.Dto.JobDto;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jobportal.Model.Dto.CandidateDto;

namespace Jobportal.Service.JobService
{
    public interface IJobService
    {
        Task<IEnumerable<GetJobDto>> GetJobsAsync(Pagination pagination);

        Task<IEnumerable<GetCandidateDto>> GetJobsApplied(int id, Pagination pagination);

        Task<CandidateMaster> ApplyJobsAsync(int userId, JobApplyDto job);


    }
}
