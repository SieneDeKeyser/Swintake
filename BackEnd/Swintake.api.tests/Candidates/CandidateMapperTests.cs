using Swintake.api.Helpers.Candidates;
using Swintake.domain.Candidates;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static Swintake.domain.Candidates.Candidate;

namespace Swintake.api.tests.Candidates
{
    public class CandidateMapperTests
    {
        [Fact]
        public void GivenACreatedCandidateDto_WhenToDomain_ThenReturnCandidateObjectWithIdGuidAndEqualFirstName()
        {
            var DTOCreated = new CandidateDto(
                Guid.NewGuid().ToString(),
                "Janneke",
                "Janssens",
                "janneke.janssens@gmail.com",
                "0470000000",
                "janneke",
                "janneke",
                "jannekeComment");

            var candidateMapper = new CandidateMapper();

            //when
            var newDomain = candidateMapper.ToDomain(DTOCreated);

            //then
            Assert.IsType<Guid>(newDomain.Id);
            Assert.Equal(newDomain.FirstName, DTOCreated.FirstName);
        }

        [Fact]
        public void GivenACandidate_WhenToDto_ThenReturnCandidateDtoObjectWithSameProperties()
        {
            //given
            var candidate = new CandidateBuilder()
                .WithId(Guid.NewGuid())
                .WithFirstName("Janneke")
                .WithLastName("Janssens")
                .WithEmail("janneke.janssens@gmail.com")
                .WithPhoneNumber("0470000000")
                .WithLinkedIn("janneke")
                .WithGitHubUsername("janneke")
                .WithComment("jannekeComment")
                .Build();

            var candidateMapper = new CandidateMapper();

            //when
            var newDto = candidateMapper.ToDto(candidate);

            //then
            Assert.Equal(candidate.Id.ToString(), newDto.Id);
            Assert.Equal(candidate.FirstName, newDto.FirstName);
            Assert.Equal(candidate.LastName, newDto.LastName);
            Assert.Equal(candidate.Email, newDto.Email);
            Assert.Equal(candidate.PhoneNumber, newDto.PhoneNumber);
            Assert.Equal(candidate.LinkedIn, newDto.LinkedIn);
            Assert.Equal(candidate.GitHubUsername, newDto.GitHubUsername);
            Assert.Equal(candidate.Comment, newDto.Comment);
        }

    }
}
