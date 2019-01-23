using Microsoft.EntityFrameworkCore;
using Swintake.domain.Candidates;
using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Swintake.domain.tests.Candidates
{
    public class CandidatesRepositoryTests
    {
        private DbContextOptions<SwintakeContext> _options;

        public CandidatesRepositoryTests()
        {
            //given 
            _options = new DbContextOptionsBuilder<SwintakeContext>()
                .UseInMemoryDatabase("swintake" + Guid.NewGuid().ToString("n"))
                .Options;
        }



        [Fact]
        public void GivenANewCandidate_WhenSaveNewCandidate_ThenNewCandidateIsSaved()
        {
            using (var context = new SwintakeContext(_options))
            {
                var janneke = new CandidateBuilder()
                        .WithId(Guid.NewGuid())
                        .WithFirstName("Janneke")
                        .WithLastName("Janssens")
                        .WithEmail("janneke.janssens@gmail.com")
                        .WithPhoneNumber("0470000000")
                        .WithGitHubUsername("janneke")
                        .WithLinkedIn("janneke")
                        .Build();

                IRepository<Candidate> candidateRepository = new CandidateRepository(context);

                //when
                candidateRepository.Save(janneke);

                //then
                var foundCandidate = context.Candidates.SingleOrDefault(cand => cand.Id == janneke.Id);
                Assert.Equal(janneke.FirstName, foundCandidate.FirstName);
            }
        }

        [Fact]
        public void GivenExistingCandidateId_WhenSearchId_ThenReturnCandidate()
        {
            using (var context = new SwintakeContext(_options))
            {
                var guidId = Guid.NewGuid();
                var janneke = new CandidateBuilder()
                    .WithId(guidId)
                    .WithFirstName("Janneke")
                    .WithLastName("Janssens")
                    .WithEmail("janneke.janssens@gmail.com")
                    .WithPhoneNumber("0470000000")
                    .WithGitHubUsername("janneke")
                    .WithLinkedIn("janneke")
                    .Build();

                IRepository<Candidate> candidateRepository = new CandidateRepository(context);

                //when
                candidateRepository.Save(janneke);
                Candidate searchCandidate = candidateRepository.Get(guidId);

                //then
                Assert.Equal(janneke.Id.ToString(), searchCandidate.Id.ToString());
            }
        }

        [Fact]
        public void GivenNonExistingCandidateId_WhenSearchId_ThenReturnNull()
        {
            using (var context = new SwintakeContext(_options))
            {
                IRepository<Candidate> candidateRepository = new CandidateRepository(context);
                Candidate searchCandidate = candidateRepository.Get(Guid.NewGuid());

                //then
                Assert.Null(searchCandidate);
            }
        }

        [Fact]
        public void GivenExistingCandidates_WhenGetAll_ThenReturnAllCandidates()
        {
            using (var context = new SwintakeContext(_options))
            {
                var guidId = Guid.NewGuid();
                var janneke = new CandidateBuilder()
                    .WithId(guidId)
                    .WithFirstName("Janneke")
                    .WithLastName("Janssens")
                    .WithEmail("janneke.janssens@gmail.com")
                    .WithPhoneNumber("0470000000")
                    .WithGitHubUsername("janneke")
                    .WithLinkedIn("janneke")
                    .Build();

                IRepository<Candidate> candidateRepository = new CandidateRepository(context);

                //when
                candidateRepository.Save(janneke);
                IList<Candidate> searchCandidate = candidateRepository.GetAll();

                //then
                Assert.Equal(1, searchCandidate.Count);
            }
        }
    }
}
