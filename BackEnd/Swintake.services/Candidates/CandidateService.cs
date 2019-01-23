using Swintake.domain;
using Swintake.domain.Candidates;
using Swintake.infrastructure.Exceptions;
using System;
using System.Collections.Generic;

namespace Swintake.services.Candidates
{
    public class CandidateService : ICandidateService
    {
        private readonly IRepository<Candidate> _candidateRepository;

        public CandidateService(IRepository<Candidate> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public Candidate AddCandidate(Candidate candidate)
        {
            if (candidate == null)
            {
                throw new EntityNotValidException("create a candidate", candidate);
            }
            
            if (Candidate.IsNotValidForCreation(candidate))
            {
                throw new EntityNotValidException("create a candidate", candidate);
            }
            else
            {
                _candidateRepository.Save(candidate);
                return candidate;
            }
        }

        public IEnumerable<Candidate> GetAllCandidates()
        {
            return _candidateRepository.GetAll();
        }

        public Candidate GetCandidateById(string id)
        {
           Candidate getCandidate = _candidateRepository.Get(Guid.Parse(id));

            if (getCandidate == null)
           {
                throw new EntityNotFoundException("get candidate by id", "candidate", new Guid(id));
           }
           return getCandidate;
        }
    }
}
