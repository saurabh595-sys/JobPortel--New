using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var Jobs = await (from j in _context.jobMasters
                              select new GetJobDto
                              {
                                  Id = j.Id,
                                  Title = j.Title,
                                  Description = j.Description
                              }).OrderBy(x => x.Id)
                               .ToListAsync();
            var count = Jobs.Count();
            if (pagination.PageSize == -1)
            {
                pagination.PageSize = count;
            }

            var result = Jobs.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                             .Take(pagination.PageSize);
            return result;


        }

        public async Task<IEnumerable<GetUserDto>> GetRecruitersAsync(Pagination pagination)
        {
            var recruiters = await (from u in _context.User
                                    where u.RoleId == 2
                                    select new GetUserDto
                                    {
                                        Id = u.Id,
                                        Name = u.Name,
                                        Email = u.Email,
                                        CreatedDate = u.CreatedDate,
                                        IsActive = u.IsActive

                                    }).OrderBy(x => x.Id)
                                .ToListAsync();
            var count = recruiters.Count();
            if (pagination.PageSize == -1)
            {
                pagination.PageSize = count;
            }

            var result = recruiters.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                             .Take(pagination.PageSize);
           
                return result;
            
             
        }

        public async Task<IEnumerable<GetUserDto>> GetUsersAsync(Pagination pagination)
        {
            var users = await (from u in _context.User
                               where u.RoleId == 3
                               select new GetUserDto
                               {
                                   Id = u.Id,
                                   Name = u.Name,
                                   Email = u.Email,
                                   CreatedDate = u.CreatedDate,
                                   IsActive = u.IsActive

                               }).OrderBy(x => x.Id)
                               .ToListAsync();
            var count = users.Count();
            if (pagination.PageSize == -1)
            {
                pagination.PageSize = count;
            }

            var result = users.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                             .Take(pagination.PageSize);
            
                return result;
           

        }

        public async Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidates(Pagination pagination)
        {
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
                                     }).OrderBy(x => x.Id)
                                    .ToListAsync();

            var count = AppliedJobs.Count();
            if (pagination.PageSize == -1)
            {
                pagination.PageSize = count;
            }

            var result = AppliedJobs.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                    .Take(pagination.PageSize);
           
                return result;
          

        }
    }
}
