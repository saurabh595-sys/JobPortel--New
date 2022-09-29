using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Model;
using Jobportal.Service.JobService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Api.Controllers.Candidate
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : BaseController
    {
        private readonly IJobService _jobservice;
        public CandidateController(IJobService jobService)
        {
            _jobservice = jobService;
        }

        [HttpPost("Jobs")]
        public async Task<IActionResult> GetJobs(Pagination pagination)
        {
            var jobs = await _jobservice.GetJobsAsync(pagination);
            if(jobs != null)
            {
                return OkResponse("Success", jobs);
            }
            return BadResponse("Unable to get List of Jobs", "");
        }

        [HttpPost("AppliedJobsByCandidate")]
        public async Task<IActionResult> GetAppliedJobs(Pagination pagination)
        {
            var jobs = await _jobservice.GetJobsApplied(UserId,pagination);
            if (jobs != null)
            {
                return OkResponse("Success", jobs);
            }
            return BadResponse("Unable to get List of Jobs", "");
        }

        [HttpPost("ApplyJob")]
        public async Task<IActionResult> GetApplyJob(JobApplyDto job)
        {
            var jobs = await _jobservice.ApplyJobsAsync(UserId, job);
            if (jobs != null)
            {
                return OkResponse("Job applied Success", jobs);
            }
            return BadResponse("Unable to apply Job", "");
        }


    }
}
