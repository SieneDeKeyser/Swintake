using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Swintake.domain.Candidates
{
    public class CandidateRepository : IRepository<Candidate>
    {
        SwintakeContext _context;

        public CandidateRepository(SwintakeContext context)
        {
            _context = context;
        }

        public Candidate Get(Guid entityId)
        {
            return _context.Candidates.FirstOrDefault(candidate => candidate.Id == entityId);
        }

        public IList<Candidate> GetAll()
        {
            var candidateList = new List<Candidate>();

            foreach (var candidate in _context.Candidates)
            {
                candidateList.Add(candidate);
            }

            return candidateList;
        }

        public Candidate Save(Candidate candidate)
        {
            _context.Candidates.Add(candidate);
            _context.SaveChanges();
            return candidate;
        }

        public Candidate Update(Candidate candidate)
        {
            throw new NotImplementedException();
        }
    }
}
