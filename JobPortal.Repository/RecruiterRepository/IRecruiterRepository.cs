using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.Repository.RecruiterRepository
{
    public interface IRecruiterRepository
    {
        Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidateAsync(int id, Pagination pagination);

        Task<IEnumerable<GetJobDto>> GetPostedJobAsync(int id, Pagination pagination);
    }
}
