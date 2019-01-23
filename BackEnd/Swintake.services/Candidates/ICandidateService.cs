using Swintake.domain.Candidates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.services.Candidates
{
    public interface ICandidateService
    {
        Candidate AddCandidate(Candidate candidate);
        IEnumerable<Candidate> GetAllCandidates();
        Candidate GetCandidateById(string id);
    }
}
