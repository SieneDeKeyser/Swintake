using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Candidates
{
    public class CandidateDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string GitHubUsername { get; set; }
        public string LinkedIn { get; set; }
        public string Comment { get; set; }

        public CandidateDto() { }

        public CandidateDto(string id, string firstName, string lastName, string email, string phoneNumber, string gitHubUsername, string linkedIn, string comment)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            GitHubUsername = gitHubUsername;
            LinkedIn = linkedIn;
            Comment = comment;
        }
    }
}
