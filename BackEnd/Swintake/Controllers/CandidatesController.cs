using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.Candidates;
using Swintake.services.Candidates;
using System.Collections.Generic;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateMapper _candidateMapper;
        private readonly ICandidateService _candidateService;

        public CandidatesController(CandidateMapper candidateMapper, ICandidateService candidateService)
        {
            _candidateMapper = candidateMapper;
            _candidateService = candidateService;
        }

        [HttpPost]
        public ActionResult<CandidateDto> CreateCandidate([FromBody] CandidateDto candidateDto)
        {
            var newcandidate = _candidateMapper.ToDto(
                     _candidateService.AddCandidate(
                        _candidateMapper.ToDomain(candidateDto)));

            return Created($"api/candidate/{newcandidate.Id}", newcandidate);
        }

        [HttpGet("{id}")]
        public ActionResult<CandidateDto> GetById(string id)
        {
            var candidate = _candidateService.GetCandidateById(id);
            return Ok(_candidateMapper.ToDto(candidate));
        }

        [HttpGet]
        public ActionResult<List<CandidateDto>> GetAll()
        {
            var candidates = _candidateService.GetAllCandidates();
            return Ok(_candidateMapper.ToDtoList(candidates));
        }
    }
}