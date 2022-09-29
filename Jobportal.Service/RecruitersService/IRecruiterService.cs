using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jobportal.Service.RecruitersService
{
    public interface IRecruiterService
    {
        Task<IEnumerable<GetJobDto>> GetPostedJobAsync(int id ,Pagination pagination);

        Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidateAsync(int id, Pagination pagination);

        Task<JobMaster> AddJobAsync(int id,AddJobDto addJobDto);

    }
}
