using Jobportal.Model.Dto.RecruiterDto;
using Jobportal.Model.Dto.UserDto;
using Jobportal.Model.Model;
using Jobportal.Service.AdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : BaseController
    {
        public readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("Candidates")]
        public async Task<IActionResult> GetCandidates(Pagination pagination)
        {
            var Candidates = await _adminService.GetUsersAsync(pagination);
            if (Candidates != null)
            {
                return OkResponse("Success", Candidates);
            }
            return BadResponse("Unable to get List of Candidates", "");
        }

        [HttpPost("Recruiters")]
        public async Task<IActionResult> GetRecruiters(Pagination pagination)
        {
            var Recruiters = await _adminService.GetRecruitersAsync(pagination);
            if (Recruiters != null)
            {
                return OkResponse("Success", Recruiters);
            }
            return BadResponse("Unable to get List of Recruiters", "");
        }

        [HttpPost("Jobs")]
        public async Task<IActionResult> GetJobs(Pagination pagination)
        {
            var Jobs = await _adminService.GetJobsAsync(pagination);
            if (Jobs != null)
            {
                return OkResponse("Success", Jobs);
            }
            return BadResponse("Unable to get List of Jobs", "");
        }



        [HttpPost("JobAppliedByCandidates")]
        public async Task<IActionResult> GetJobAppliedByCandidates(Pagination pagination)
        {
            var Jobs = await _adminService.GetJobAppliedByCandidates(pagination);
            if (Jobs != null)
            {
                return OkResponse("Success", Jobs);
            }
            return BadResponse("Unable to get List of Jobs", "");
        }

        [HttpDelete("job/{Id}")]
        public async Task<IActionResult> DeleteJob(int Id)
        {
            var Job = await _adminService.DeleteJobAsync(Id);
            if (Job)
            {
                return OkResponse("Success", Job);
            }
            else
            {
                return BadResponse("Unable to delete job", "");
            }
        }

        [HttpDelete("Recruiter/{Id}")]
        public async Task<IActionResult> DeleteRecruiter(int Id)
        {
            var Recruiter = await _adminService.DeleteRecruiterAsync(Id);
            if (Recruiter)
            {
                return OkResponse("Success", Recruiter);
            }
            else
            {
                return BadResponse("Unable to delete Recruiter", "");
            }
        }

        [HttpDelete("User/{Id}")]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var User = await _adminService.DeleteUserAsync(Id);
            if (User)
            {
                return OkResponse("Success", User);
            }
            else
            {
                return BadResponse("Unable to delete User", "");
            }
        }


        [HttpPost("Export")]
        public async Task<IActionResult> ExportFile(Pagination pagination)
        {
            IEnumerable<GetUserDto> candidatesList = await _adminService.GetUsersAsync(pagination);
            IEnumerable<GetUserDto> recruitersList = await _adminService.GetRecruitersAsync(pagination);
            IEnumerable<GetJobAppliedByCandidateDto> jobsAppliedByCandidatesList = await _adminService.GetJobAppliedByCandidates(pagination);

            List<IEnumerable<dynamic>> data = new List<IEnumerable<dynamic>>();
            data.Add(candidatesList);
            data.Add(recruitersList);
            data.Add(jobsAppliedByCandidatesList);
            return Export(data);
        }

    }
}
