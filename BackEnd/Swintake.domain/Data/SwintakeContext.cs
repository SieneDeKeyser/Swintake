using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swintake.domain.Campaigns;
using Swintake.domain.Candidates;
using Swintake.domain.JobApplications;
using Swintake.domain.JobApplications.SelectionSteps;
using Swintake.domain.Users;

namespace Swintake.domain.Data
{
    public partial class SwintakeContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DbSet<User> Users { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        public DbSet<SelectionStep> SelectionSteps { get; set; }

        public SwintakeContext(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public SwintakeContext(DbContextOptions<SwintakeContext> options) : base(options)
        {
        }

        public SwintakeContext(DbContextOptions<SwintakeContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .OwnsOne(u => u.UserSecurity, us =>
                {
                    us.Property(u => u.PasswordHashedAndSalted).HasColumnName("PasswordHashed");
                    us.Property(u => u.AppliedSalt).HasColumnName("AppliedSalt");
                });

            modelBuilder.Entity<Campaign>()
                .ToTable("Campaigns")
                .HasKey(campaign => campaign.Id);

            modelBuilder.Entity<Candidate>()
                .ToTable("Candidates")
                .HasKey(candidate => candidate.Id);

            modelBuilder.Entity<JobApplication>()
                        .ToTable("JobApplications")
                        .HasKey(jobapp => jobapp.Id);

            modelBuilder.Entity<JobApplication>()
                        .HasOne(jobapp => jobapp.Candidate)
                        .WithMany()
                        .HasForeignKey(jobapp => jobapp.CandidateId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobApplication>()
                        .HasOne(jobapp => jobapp.Campaign)
                        .WithMany()
                        .HasForeignKey(jobapp => jobapp.CampaignId)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SelectionStep>()
                .ToTable("SelectionStep")
                .HasKey(selectionStep => new {selectionStep.JobApplicationId, selectionStep.Description});

            modelBuilder.Entity<SelectionStep>()
                .HasOne(sel => sel.JobApplication)
                .WithMany(jobApp => jobApp.SelectionSteps)
                .HasForeignKey(sel => sel.JobApplicationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CvScreening>();
            //    .ToTable("CvScreening");

            modelBuilder.Entity<FinalDecision>();
            //    .ToTable("FinalDecision");

            modelBuilder.Entity<FirstInterview>();
            //    .ToTable("FirstInterview");

            modelBuilder.Entity<GroupInterview>();
            //    .ToTable("GroupInterview");

            modelBuilder.Entity<PhoneScreening>();
            //    .ToTable("PhoneScreening");

            modelBuilder.Entity<TestResult>();


            base.OnModelCreating(modelBuilder);

            SeedData(modelBuilder);
        }   
    }

}
