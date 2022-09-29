using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Repository.AdminRepository
{
    public  class AdminRepository:Repository<User>, IAdminRepository
    {
        public AdminRepository(Context context):base(context)
        {

        }
        public async Task<IEnumerable<GetJobDto>> GetJobsAsync(Pagination pagination)
        {

            var count = 0;
            if (pagination.PageSize == -1)
            {
                count = await (from j in _context.jobMasters
                               select j).CountAsync();
            }

            var Jobs = await (from j in _context.jobMasters
                               select new GetJobDto
                               {
                                   Id = j.Id,
                                   Title = j.Title,
                                   Description = j.Description

                               })
                               .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                               .Take(pagination.PageSize == -1 ? count : pagination.PageSize)
                               .OrderBy(x => x.Id)
                               .ToListAsync();

            return Jobs;


        }

        public async Task<IEnumerable<GetUserDto>> GetRecruitersAsync(Pagination pagination)
        {
            
            var count = 0;
            if (pagination.PageSize == -1)
            {
                count = await (from u in _context.User
                               where u.RoleId == 2
                               select u).CountAsync();
            }

            var users = await (from u in _context.User
                               where u.RoleId == 2
                               select new GetUserDto
                               {
                                   Id = u.Id,
                                   Name = u.Name,
                                   Email = u.Email,
                                   CreatedDate = u.CreatedDate,
                                   IsActive = u.IsActive

                               })
                               .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                               .Take(pagination.PageSize == -1 ? count : pagination.PageSize)
                               .OrderBy(x => x.Id)
                               .ToListAsync();

            return users;

        }

        public async Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination)
        {
            var count = 0;
            if(pagination.PageSize == -1)
            {
                    count = await (from u in _context.User
                                   where u.RoleId == 3
                                   select u).CountAsync();
            }

            var users = await (from u in _context.User
                               where u.RoleId == 3
                               select new GetUserDto
                               {
                                   Id = u.Id,
                                   Name = u.Name,
                                   Email = u.Email,
                                   CreatedDate = u.CreatedDate,
                                   IsActive = u.IsActive

                               })
                               .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                               .Take(pagination.PageSize == -1 ? count : pagination.PageSize)
                               .OrderBy(x => x.Id)
                               .ToListAsync();
            
                return users;
           

        }

        public async Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidates(Pagination pagination)
        {

            var count = 0;
            if (pagination.PageSize == -1)
            {
                count = await (from u in _context.User
                               join a in _context.candidateMasters on u.Id equals a.CandidateId
                               join j in _context.jobMasters on a.AppliedJobId equals j.Id
                               select a
                               ).CountAsync();
            }

            var AppliedJobs = await (from u in _context.User
                               join a in _context.candidateMasters on u.Id equals a.CandidateId
                               join j in _context.jobMasters on a.AppliedJobId equals j.Id
                               select new GetJobAppliedByCandidateDto
                               {
                                   Id = u.Id,
                                   CandidateName = u.Name,
                                   JobTitle = j.Title,
                                   Description = j.Description,
                                   AppliedAt = a.AppliedAt
                               })
                               .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                               .Take(pagination.PageSize == -1 ? count : pagination.PageSize)
                               .OrderBy(x => x.Id)
                               .ToListAsync();

            return AppliedJobs;


        }
    }
}
