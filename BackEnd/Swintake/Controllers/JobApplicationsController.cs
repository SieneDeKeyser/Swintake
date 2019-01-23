using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.JobApplications;
using Swintake.domain.JobApplications;
using Swintake.services.JobApplications;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly JobApplicationMapper _jobApplicationMapper;

        public JobApplicationsController(IJobApplicationService jobApplicationService, JobApplicationMapper jobApplicationMapper)
        {
            _jobApplicationService = jobApplicationService;
            _jobApplicationMapper = jobApplicationMapper;
        }

        [HttpPost]
        public ActionResult<JobApplicationDto> CreateJobApplication([FromBody] CreateJobApplicationDto jobApplicationDto)
        {
            var newJobApplication = _jobApplicationMapper.ToDto(
                _jobApplicationService.AddJobApplication(
                    _jobApplicationMapper.ToNewDomain(jobApplicationDto)));

            return Created($"api/jobapplications/{newJobApplication.Id}", newJobApplication);
        }

        [HttpGet("{id}")]
        public ActionResult<JobApplicationDto> GetById(string id)
        {
            var jobApplicationDto = _jobApplicationService.GetJobApplicationById(id);
            return Ok(_jobApplicationMapper.ToDto(jobApplicationDto));
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobApplicationDto>> GetAll()
        {
            return Ok(_jobApplicationService.GetJobApplications()
                .Select(jobapp => _jobApplicationMapper.ToDto(jobapp)).ToList());

        }

 
        [HttpPut]
        [Route("nextStep/{id}")]
        public ActionResult<JobApplicationDto> UpdateJobApplication(string id, [FromBody] string comment = null)
        {
            var jobapp = _jobApplicationService.GoToNextSelectionStepInSelectionProcess(id, comment);
            var testjobappdto =_jobApplicationMapper.ToDto(jobapp);
            return Ok(testjobappdto);
        }

        [HttpPut]
        [Route("reject/{id}")]
        public ActionResult<JobApplicationDto> Reject(string id)
        {
            var rejectedDomainJobApplication = _jobApplicationService.RejectJobApplication(id);
            var jobApplicationDtoToReturn = _jobApplicationMapper.ToDto(rejectedDomainJobApplication);
            return Ok(jobApplicationDtoToReturn);
        }

        [HttpPut]
        [Route("accept/{id}")]
        public ActionResult<JobApplicationDto> Accept(string id)
        {
            var acceptJobApplication = _jobApplicationService.AcceptJobApplication(id);
            var jobApplicationDtoToReturn = _jobApplicationMapper.ToDto(acceptJobApplication);
            return Ok(jobApplicationDtoToReturn);
        }
    }
}