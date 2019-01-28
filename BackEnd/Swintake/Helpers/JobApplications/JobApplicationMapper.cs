using Swintake.domain.JobApplications;
using Swintake.infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using Swintake.api.Helpers.Campaigns;
using Swintake.api.Helpers.Candidates;
using Swintake.domain.JobApplications.SelectionSteps;
using Swintake.api.Helpers.JobApplications.Selection;

namespace Swintake.api.Helpers.JobApplications
{
    public class JobApplicationMapper : Mapper<JobApplicationDto, JobApplication>
    {
        private readonly CampaignMapper _campaignMapper;
        private readonly CandidateMapper _candidateMapper;
        private readonly SelectionStepMapper _selectionStepMapper;

        public JobApplicationMapper(CampaignMapper campaignMapper, CandidateMapper candidateMapper)
        {
            _campaignMapper = campaignMapper;
            _candidateMapper = candidateMapper;
            _selectionStepMapper = new SelectionStepMapper();
        }

        public override JobApplication ToDomain(JobApplicationDto dtoObject)
        {
            return new JobApplicationBuilder()
                .WithId(new Guid(dtoObject.Id))
                .WithCampaignId(new Guid(dtoObject.CampaignId))
                .WithCandidateId(new Guid(dtoObject.CandidateId))
                .WithStatus(StatusJobApplication.Active)
                .Build();
        }

        public virtual JobApplication ToNewDomain(CreateJobApplicationDto dtoObject)
        {
            return new JobApplicationBuilder()
                .WithId(Guid.NewGuid())
                .WithCampaignId(new Guid(dtoObject.CampaignId))
                .WithCandidateId(new Guid(dtoObject.CandidateId))
                .WithStatus(StatusJobApplication.Active)
                .Build();
        }

        public override JobApplicationDto ToDto(JobApplication domainObject)
        {
            
            var jobappDto = new JobApplicationDto()
            {
                Id = domainObject.Id.ToString(),
                CandidateId = domainObject.CandidateId.ToString(),         
                CampaignId = domainObject.CampaignId.ToString(),
                Status = domainObject.Status.ToString(),
                Candidate = _candidateMapper.ToDto(domainObject.Candidate),
                Campaign = _campaignMapper.ToDto(domainObject.Campaign)
            };
            if (domainObject.CurrentSelectionStep != null)
            {
                jobappDto.SelectionSteps = _selectionStepMapper.ToDtoList(domainObject.SelectionSteps);
                jobappDto.CurrentSelectionStep = _selectionStepMapper.ToDto(domainObject.CurrentSelectionStep);
            }
            return jobappDto;
        }

    }

    public class SelectionStepMapper 
    {
        public List<SelectionStepDto> ToDtoList(List<SelectionStep> selectionstep)
        {
            return selectionstep.Select(sel => { return ToDto(sel); }).ToList();
        }

        public SelectionStepDto ToDto(SelectionStep domainObject)
        {
            return new SelectionStepDto()
            {
                JobApplicationId = domainObject.JobApplicationId,
                Comment = domainObject.Comment,
                Description = domainObject.Description
            };
        }


    }
}
