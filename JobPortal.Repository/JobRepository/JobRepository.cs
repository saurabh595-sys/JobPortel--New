using Jobportal.Model.Dto.CandidateDto;
using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.Inrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Repository.JobRepository
{
   public class JobRepository :Repository<JobMaster> ,IJobRepository
    {
        public JobRepository(Context context):base(context)
        {

        }
        public async Task<IEnumerable<GetCandidateDto>> GetJobsApplied(int id, Pagination pagination)
        {
            var JobApplied = await (from j in _context.jobMasters
                                    join a in _context.candidateMasters on j.Id equals a.AppliedJobId
                                    join u in _context.User on a.CandidateId equals u.Id
                                    where a.CandidateId == id
                                    select new GetCandidateDto
                                    {
                                        Id = u.Id,
                                        CandidateName = u.Name,
                                        JobTitle = j.Title,
                                        JobDescription = j.Description,
                                        AppliedAt = a.AppliedAt
                                    }).OrderBy(x => x.Id)
                                   .ToListAsync();
            var count = JobApplied.Count();
            if (pagination.PageSize == -1)
            {
                pagination.PageSize = count;
            }

            var result = JobApplied.Skip((pagination.PageNumber - 1) * pagination.PageSize)
                           .Take(pagination.PageSize);
            return result;

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
    }
}
