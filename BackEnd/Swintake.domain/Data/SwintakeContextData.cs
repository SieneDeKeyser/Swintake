using Microsoft.EntityFrameworkCore;
using Swintake.domain.Users;
using System;
using System.Collections.Generic;
using Swintake.domain.Campaigns;
using Swintake.domain.Candidates;
using Swintake.domain.JobApplications.SelectionSteps;

namespace Swintake.domain.Data
{
    class SwintakeContextData
    {
        internal Campaign dotNetClass = new Campaign.CampaignBuilder()
             .WithId(Guid.NewGuid())
             .WithName("dotnet class 2019")
             .WithClient("mixed")
             .WithClassStartDate(DateTime.Now.AddMonths(2))
             .WithStartDate(DateTime.Now.AddMonths(1))
             .WithComment("max 8 candidates")
             .WithStatus(CampaignStatus.Active).Build();

        internal Campaign javaClass = new Campaign.CampaignBuilder()
             .WithId(Guid.NewGuid())
             .WithName("Java academy 2019")
             .WithClient("CM")
             .WithClassStartDate(DateTime.Now)
             .WithStartDate(DateTime.Now)
             .WithComment("at cm location")
             .WithStatus(CampaignStatus.Active).Build();

        internal Campaign javascriptClass = new Campaign.CampaignBuilder()
             .WithId(Guid.NewGuid())
             .WithName("Short javascript bootcamp")
             .WithClient("open for all")
             .WithClassStartDate(DateTime.Now.AddDays(50))
             .WithStartDate(DateTime.Now.AddDays(10))
             .WithComment("")
             .WithStatus(CampaignStatus.Active).Build();

        internal Candidate gwen = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithFirstName("Gwen")
            .WithLastName("Jamroziak")
            .WithPhoneNumber("0472020406")
            .WithEmail("gwen.jamroziak@cegeka.com")
            .WithGitHubUsername("gwenjamroziak")
            .WithLinkedIn("gwenjamroziak")
            .WithComment("")
            .Build();

        internal Candidate caroline = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithFirstName("Caroline")
            .WithLastName("Callens")
            .WithPhoneNumber("0472030507")
            .WithEmail("caroline.callens@cegeka.com")
            .WithGitHubUsername("carolinecallens")
            .WithLinkedIn("carolinecallens")
            .WithComment("")
            .Build();

        internal Candidate siene = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithFirstName("Siene")
            .WithLastName("Dekeyser")
            .WithPhoneNumber("0472040608")
            .WithEmail("siene.dekeyser@cegeka.com")
            .WithGitHubUsername("sienedekeyser")
            .WithLinkedIn("sienedekeyser")
            .WithComment("")
            .Build();

        internal Candidate luc = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithFirstName("Luc")
            .WithLastName("Verhoeven")
            .WithPhoneNumber("0472050403")
            .WithEmail("luc.verhoeven@carglass.be")
            .WithGitHubUsername("lucverhoeven")
            .WithLinkedIn("lucverhoeven")
            .WithComment("")
            .Build();

    }

    public partial class SwintakeContext
    {
        protected void SeedData(ModelBuilder modelbuilder)
        {
            var seedData = new SwintakeContextData();

            var idReinout = Guid.NewGuid();
            modelbuilder.Entity<User>(u =>
            {
                u.HasData(new
                {
                    Id = idReinout,
                    FirstName = "Reinout",
                    Email = "reinout@switchfully.com"
                });
                u.OwnsOne(us => us.UserSecurity).HasData(new
                {
                    PasswordHashedAndSalted = "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=",
                    AppliedSalt = "NgBFEGiYlnKAVlAkBj6Qkg==",
                    UserId = idReinout
                });
            });

            var idNiels = Guid.NewGuid();
            modelbuilder.Entity<User>(u =>
            {
                u.HasData(new
                {
                    Id = idNiels,
                    FirstName = "Niels",
                    Email = "niels@switchfully.com"
                });
                u.OwnsOne(us => us.UserSecurity).HasData(new
                {
                    PasswordHashedAndSalted = "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=",
                    AppliedSalt = "rODZhnBsLGRP908sBZiXzg==",
                    UserId = idNiels
                });
            });

            modelbuilder.Entity<Campaign>(camp => { camp.HasData(seedData.dotNetClass); });
            modelbuilder.Entity<Campaign>(camp => { camp.HasData(seedData.javaClass); });
            modelbuilder.Entity<Campaign>(camp => { camp.HasData(seedData.javascriptClass); });
            modelbuilder.Entity<Candidate>(cand => { cand.HasData(seedData.gwen); });
            modelbuilder.Entity<Candidate>(cand => { cand.HasData(seedData.caroline); });
            modelbuilder.Entity<Candidate>(cand => { cand.HasData(seedData.siene); });
            modelbuilder.Entity<Candidate>(cand => { cand.HasData(seedData.luc); });

        }
    }
}
