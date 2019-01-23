using Swintake.infrastructure.builders;
using System;
using System.ComponentModel.DataAnnotations;

namespace Swintake.domain.Candidates
{
    public class Candidate : Entity
    {
        [MaxLength(60)]
        public string FirstName { get; private set; }
        [MaxLength(60)]
        public string LastName { get; private set; }
        [MaxLength(100)]
        public string Email { get; private set; }
        [MaxLength(20)]
        public string PhoneNumber { get; private set; }
        [MaxLength(100)]
        public string GitHubUsername { get; private set; }
        [MaxLength(200)]
        public string LinkedIn { get; private set; }
        [MaxLength(500)]
        public string Comment { get; private set; }

        private Candidate() { }

        public Candidate(CandidateBuilder candidateBuilder) : base(candidateBuilder.Id)
        {
            FirstName = candidateBuilder.FirstName;
            LastName = candidateBuilder.LastName;
            Email = candidateBuilder.Email;
            PhoneNumber = candidateBuilder.PhoneNumber;
            GitHubUsername = candidateBuilder.GitHubUsername;
            LinkedIn = candidateBuilder.LinkedIn;
            Comment = candidateBuilder.Comment;
        }

        public static bool IsNotValidForCreation(Candidate candidate)
        {
            return (candidate.Id == null
                    || candidate.Id == Guid.Empty
                    || string.IsNullOrWhiteSpace(candidate.FirstName)
                    || string.IsNullOrWhiteSpace(candidate.LastName)
                    || string.IsNullOrWhiteSpace(candidate.Email)
                    || string.IsNullOrWhiteSpace(candidate.PhoneNumber)
                    || !IsEmailValid(candidate.Email));
        }

        private static bool IsEmailValid(string email)
        {
            return email.Contains('@');
        }
    }

    public class CandidateBuilder : Builder<Candidate>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string GitHubUsername { get; set; }
        public string LinkedIn { get; set; }
        public string Comment { get; set; }

        public static CandidateBuilder NewCandidate()
        {
            return new CandidateBuilder();
        }

        public CandidateBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public CandidateBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public CandidateBuilder WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public CandidateBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CandidateBuilder WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }

        public CandidateBuilder WithGitHubUsername(string gitUserName)
        {
            GitHubUsername = gitUserName;
            return this;
        }

        public CandidateBuilder WithLinkedIn(string linkedIn)
        {
            LinkedIn = linkedIn;
            return this;
        }

        public CandidateBuilder WithComment(string comment)
        {
            Comment = comment;
            return this;
        }

        public override Candidate Build()
        {
            return new Candidate(this);
        }
    }
}
