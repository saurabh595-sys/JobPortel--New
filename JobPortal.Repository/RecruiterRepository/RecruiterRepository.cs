using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.RecruiterRepository
{
   public class RecruiterRepository: Repository<User>, IRecruiterRepository
    {
        public RecruiterRepository(Context context) : base(context)
        {

        }
        public async Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidateAsync(int id, Pagination pagination)
        {

            var AppliedJobs = await (from u in _context.User
                                     join a in _context.candidateMasters on u.Id equals a.CandidateId
                                     join j in _context.jobMasters on a.AppliedJobId equals j.Id
                                     where j.CreatedBy == id
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


        public async Task<IEnumerable<GetJobDto>> GetPostedJobAsync(int id, Pagination pagination)
        {
            var Jobs = await (from j in _context.jobMasters
                              where j.CreatedBy == id
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
    }
}
