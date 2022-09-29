using Jobportal.Model.Dto.JobDto;
using Jobportal.Model.Model;
using Jobportal.Service.RecruitersService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JobPortal.Api.Controllers.Recruteur
{

    [Authorize(Policy = "AdminRecruiterOnly")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : BaseController
    {
        public readonly IRecruiterService _recruiterService;
        public RecruiterController(IRecruiterService recruiterService)
        {
            _recruiterService = recruiterService;
        }

        [HttpPost("PostedJob")]
        public async Task<IActionResult> GetPostedJob(Pagination pagination)
        {
            var Jobs = await _recruiterService.GetPostedJobAsync(UserId, pagination);
            if (Jobs != null)
            {
                return OkResponse("Success", Jobs);
            }
            else
            {
                return NotFoundResponse("Jobs Not Found", "");
            }
        }


        [HttpPost("JobAppliedByCandidate")]
        public async Task<IActionResult> JobAppliedByCandidate(Pagination pagination)
        {
            var Jobs = await _recruiterService.GetJobAppliedByCandidateAsync(UserId, pagination);
            if (Jobs != null)
            {
                return OkResponse("Success", Jobs);
            }
            else
            {
                return NotFoundResponse("Jobs Not Found", "");
            }
        }

        [HttpPost("AddJob")]
        public async Task<IActionResult> AddJob(AddJobDto addJobDto)
        {
            var Job = await _recruiterService.AddJobAsync(UserId, addJobDto);
            if (Job != null)
            {
                return OkResponse("Success", Job);
            }
            else
            {
                return NotFoundResponse("Unable TO Add New Job ", "");
            }
        }
    }
}
