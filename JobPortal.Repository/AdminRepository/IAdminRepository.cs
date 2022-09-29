using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Inrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobPortal.Repository.AdminRepository
{
    public interface IAdminRepository :IRepository<User>
    {
        Task<IEnumerable<GetJobDto>> GetJobsAsync(Pagination pagination);
        Task<IEnumerable<GetUserDto>> GetRecruitersAsync(Pagination pagination);
        Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination);
        Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidates(Pagination pagination);

    }
}
