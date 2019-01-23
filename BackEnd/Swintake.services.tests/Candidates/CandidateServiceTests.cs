using NSubstitute;
using Swintake.domain;
using Swintake.domain.Candidates;
using Swintake.infrastructure.Exceptions;
using Swintake.services.Candidates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Xunit;

namespace Swintake.services.tests.Candidates
{
    public class CandidateServiceTests
    {
        private readonly CandidateService _candidateService;
        private readonly IRepository<Candidate> _candidateRepository;

        public CandidateServiceTests()
        {
            _candidateRepository = Substitute.For<IRepository<Candidate>>();
            _candidateService = new CandidateService(_candidateRepository);
        }

        internal Candidate janneke = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithFirstName("Janneke")
            .WithLastName("Janssens")
            .WithEmail("janneke.janssens@gmail.com")
            .WithPhoneNumber("0470000000")
            .WithGitHubUsername("janneke")
            .WithLinkedIn("janneke")
            .Build();

        internal Candidate mieke = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithFirstName("Mieke")
            .WithLastName("Miekens")
            .WithEmail("mieke.miekens@gmail.com")
            .WithPhoneNumber("0470000000")
            .WithGitHubUsername("mieke")
            .WithLinkedIn("mieke")
            .Build();

        [Fact]
        public void CreateCandidate_HappyPath()
        {
            Candidate createdCandidate = _candidateService.AddCandidate(janneke);
            Assert.NotNull(createdCandidate);
            Assert.NotEqual(createdCandidate.Id, Guid.Empty);
        }

        [Fact]
        public void GivenCandidateThatIsNotValidForCreation_WhenCreateCandidate_ThenThrowException()
        {
            Candidate jannekeNotValid = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithLastName("Janssens")
            .WithEmail("janneke.janssens@gmail.com")
            .WithPhoneNumber("0470000000")
            .WithGitHubUsername("janneke")
            .WithLinkedIn("janneke")
            .Build();

            Exception ex = Assert.Throws<EntityNotValidException>(() => _candidateService.AddCandidate(jannekeNotValid));
            Assert.Contains("candidate", ex.Message);
        }

        [Fact]
        public void GivenMockDatabaseWith2Objects_GetAllCandidates__ReturnListOfTwoObjects()
        {
            _candidateRepository.GetAll().Returns(new List<Candidate>() { janneke, mieke });

            var result = _candidateService.GetAllCandidates().Count();

            Assert.Equal(2, result);
        }
    }
}
