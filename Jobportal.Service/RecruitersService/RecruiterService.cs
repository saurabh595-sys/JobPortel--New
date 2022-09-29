using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Model;
using JobPortal.Repository.Contexts;
using JobPortal.Repository.JobRepository;
using JobPortal.Repository.RecruiterRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobportal.Service.RecruitersService
{
  public  class RecruiterService : IRecruiterService
    {
      
        private readonly IJobRepository _jobRepository;
        private readonly IRecruiterRepository _recruiterRepository;
        public RecruiterService(IJobRepository job, IRecruiterRepository recruiterRepository )
        { 
            _jobRepository = job;
            _recruiterRepository = recruiterRepository;
            
        }

        public async Task<JobMaster> AddJobAsync(int id,AddJobDto addJobDto)
        {
            if (addJobDto != null)
            {
                JobMaster jobMaster = new JobMaster();
                jobMaster.Title = addJobDto.Title;
                jobMaster.Description = addJobDto.Description;
                jobMaster.CreatedBy = id;
                jobMaster.CreatedAt = DateTime.Now;
                jobMaster.isActive = true;
                return await _jobRepository.AddAsync(jobMaster);
            }
            return null;
        }

        public async Task<IEnumerable<GetJobAppliedByCandidateDto>> GetJobAppliedByCandidateAsync(int id, Pagination pagination)
        {

            var AppliedJobs = await _recruiterRepository.GetJobAppliedByCandidateAsync(id, pagination);
            if (AppliedJobs != null)
            {
                return AppliedJobs;
            }
            else
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<GetJobDto>> GetPostedJobAsync(int id,Pagination pagination)
        {
            var Jobs = await _recruiterRepository.GetPostedJobAsync(id, pagination);
            if (Jobs != null)
                return Jobs;
            return null;

        }


    }
}
