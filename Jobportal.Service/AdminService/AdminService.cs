using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using JobPortal.Repository.AdminRepository;
using JobPortal.Repository.JobRepository;
using JobPortal.Repository.UserRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jobportal.Service.AdminService
{
    public class AdminService : IAdminService
    {
        
        private readonly IJobRepository _jobRepository;
        private readonly IUserRepository _userRepository;
        private readonly IAdminRepository _adminRepository;
        public AdminService(IJobRepository jobRepository, IUserRepository userRepository,IAdminRepository adminRepository)
        {
            _jobRepository = jobRepository;
            _userRepository = userRepository;
            _adminRepository = adminRepository;
        
        }



        public async Task<IEnumerable<GetJobDto>> GetJobsAsync(Pagination pagination)
        {
            var Jobs = await _adminRepository.GetJobsAsync(pagination);
            if (Jobs != null)
                return Jobs;
            return null;

        }

        public async Task<IEnumerable<GetUserDto>> GetRecruitersAsync(Pagination pagination)
        {
            var recruiters = await _adminRepository.GetRecruitersAsync(pagination);
            if (recruiters != null)
                return recruiters;
            return null;
        }

        public async Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination)
        {
            var users = await _adminRepository.GetUsersAsync(pagination);
            if (users != null)
                return users;
            return null;

        }

        public async Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidates(Pagination pagination)
        {
            var AppliedJobs = await _adminRepository.GetJobAppliedByCandidates(pagination);
            if (AppliedJobs != null)
                return AppliedJobs;
            return null;
               
        }


        public async Task<bool> DeleteJobAsync(int id)
        {
            JobMaster job = await _jobRepository.GetByIdAsync(id);
            job.isActive = false;
            if ( _jobRepository.UpdateAsync(job).IsCompleted)
            {
                return true;
            }
            {
                return false;
            }
            
        }

        public async Task<bool> DeleteRecruiterAsync(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            user.IsActive = false;
            if (_userRepository.UpdateAsync(user).IsCompleted)
            {
                return true;
            }
            {
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            user.IsActive = false;
            if (_userRepository.UpdateAsync(user).IsCompleted)
            {
                return true;
            }
            {
                return false;
            }
        }
    }
}
