using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jobportal.Service.AdminService
{
    public interface IAdminService
    {
        Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination);
        Task<IEnumerable<GetUserDto>> GetRecruitersAsync(Pagination pagination);
        Task<IEnumerable<GetJobDto>> GetJobsAsync(Pagination pagination);
        Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidates(Pagination pagination);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> DeleteRecruiterAsync(int id);
        Task<bool> DeleteJobAsync(int id);

    }
}
