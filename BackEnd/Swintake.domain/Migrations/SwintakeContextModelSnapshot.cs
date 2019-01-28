﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Swintake.domain.Data;

namespace Swintake.domain.Migrations
{
    [DbContext(typeof(SwintakeContext))]
    partial class SwintakeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Swintake.domain.Campaigns.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ClassStartDate");

                    b.Property<string>("Client")
                        .HasMaxLength(60);

                    b.Property<string>("Comment")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasMaxLength(60);

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");

                    b.HasData(
                        new { Id = new Guid("3ca351a3-5aa5-4daa-b285-36f64e08dc7d"), ClassStartDate = new DateTime(2019, 3, 25, 13, 28, 46, 173, DateTimeKind.Local), Client = "mixed", Comment = "max 8 candidates", Name = "dotnet class 2019", StartDate = new DateTime(2019, 2, 25, 13, 28, 46, 174, DateTimeKind.Local), Status = 1 },
                        new { Id = new Guid("517b5e34-2ae9-4467-896d-ce4cbe474af4"), ClassStartDate = new DateTime(2019, 1, 25, 13, 28, 46, 175, DateTimeKind.Local), Client = "CM", Comment = "at cm location", Name = "Java academy 2019", StartDate = new DateTime(2019, 1, 25, 13, 28, 46, 175, DateTimeKind.Local), Status = 1 },
                        new { Id = new Guid("aed64cf9-e6fd-4cb8-93e2-953389a287fb"), ClassStartDate = new DateTime(2019, 3, 16, 13, 28, 46, 175, DateTimeKind.Local), Client = "open for all", Comment = "", Name = "Short javascript bootcamp", StartDate = new DateTime(2019, 2, 4, 13, 28, 46, 175, DateTimeKind.Local), Status = 1 }
                    );
                });

            modelBuilder.Entity("Swintake.domain.Candidates.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .HasMaxLength(60);

                    b.Property<string>("GitHubUsername")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasMaxLength(60);

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Candidates");

                    b.HasData(
                        new { Id = new Guid("235cffb9-331f-40be-b5d0-473cfa5cd9f5"), Comment = "", Email = "gwen.jamroziak@cegeka.com", FirstName = "Gwen", GitHubUsername = "gwenjamroziak", LastName = "Jamroziak", LinkedIn = "gwenjamroziak", PhoneNumber = "0472020406" },
                        new { Id = new Guid("7907e3f4-4892-47e1-abfe-28fe150b8775"), Comment = "", Email = "caroline.callens@cegeka.com", FirstName = "Caroline", GitHubUsername = "carolinecallens", LastName = "Callens", LinkedIn = "carolinecallens", PhoneNumber = "0472030507" },
                        new { Id = new Guid("d74190f2-cdc5-4642-a968-e2384362f64e"), Comment = "", Email = "siene.dekeyser@cegeka.com", FirstName = "Siene", GitHubUsername = "sienedekeyser", LastName = "Dekeyser", LinkedIn = "sienedekeyser", PhoneNumber = "0472040608" },
                        new { Id = new Guid("95a60e2b-aaf6-4bf1-aa24-c7d4f2bf0a2b"), Comment = "", Email = "luc.verhoeven@carglass.be", FirstName = "Luc", GitHubUsername = "lucverhoeven", LastName = "Verhoeven", LinkedIn = "lucverhoeven", PhoneNumber = "0472050403" }
                    );
                });

            modelBuilder.Entity("Swintake.domain.FilesToUpload.FileToUpload", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FileContent");

                    b.Property<string>("FileName");

                    b.Property<int>("Filetype");

                    b.Property<Guid>("JobApplicationId");

                    b.Property<byte[]>("UploadedFileContent");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.JobApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CampaignId");

                    b.Property<Guid>("CandidateId");

                    b.Property<string>("CurrentSelectionStepDescription");

                    b.Property<Guid?>("CurrentSelectionStepJobApplicationId");

                    b.Property<Guid?>("CvGuid");

                    b.Property<Guid?>("MotivationLetterGuid");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("CvGuid")
                        .IsUnique()
                        .HasFilter("[CvGuid] IS NOT NULL");

                    b.HasIndex("MotivationLetterGuid")
                        .IsUnique()
                        .HasFilter("[MotivationLetterGuid] IS NOT NULL");

                    b.HasIndex("CurrentSelectionStepJobApplicationId", "CurrentSelectionStepDescription");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.SelectionStep", b =>
                {
                    b.Property<Guid>("JobApplicationId");

                    b.Property<string>("Description")
                        .HasMaxLength(90);

                    b.Property<string>("Comment")
                        .HasMaxLength(500);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.HasKey("JobApplicationId", "Description");

                    b.ToTable("SelectionStep");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SelectionStep");
                });

            modelBuilder.Entity("Swintake.domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = new Guid("412cd99b-26a1-4784-8e3e-ecbc63ffc3de"), Email = "reinout@switchfully.com", FirstName = "Reinout" },
                        new { Id = new Guid("6ba2098b-7e1d-4d25-af47-f50f43c4e5b0"), Email = "niels@switchfully.com", FirstName = "Niels" }
                    );
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.CvScreening", b =>
                {
                    b.HasBaseType("Swintake.domain.JobApplications.SelectionSteps.SelectionStep");


                    b.ToTable("CvScreening");

                    b.HasDiscriminator().HasValue("CvScreening");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.FinalDecision", b =>
                {
                    b.HasBaseType("Swintake.domain.JobApplications.SelectionSteps.SelectionStep");


                    b.ToTable("FinalDecision");

                    b.HasDiscriminator().HasValue("FinalDecision");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.FirstInterview", b =>
                {
                    b.HasBaseType("Swintake.domain.JobApplications.SelectionSteps.SelectionStep");


                    b.ToTable("FirstInterview");

                    b.HasDiscriminator().HasValue("FirstInterview");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.GroupInterview", b =>
                {
                    b.HasBaseType("Swintake.domain.JobApplications.SelectionSteps.SelectionStep");


                    b.ToTable("GroupInterview");

                    b.HasDiscriminator().HasValue("GroupInterview");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.PhoneScreening", b =>
                {
                    b.HasBaseType("Swintake.domain.JobApplications.SelectionSteps.SelectionStep");


                    b.ToTable("PhoneScreening");

                    b.HasDiscriminator().HasValue("PhoneScreening");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.TestResult", b =>
                {
                    b.HasBaseType("Swintake.domain.JobApplications.SelectionSteps.SelectionStep");


                    b.ToTable("TestResult");

                    b.HasDiscriminator().HasValue("TestResult");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.JobApplication", b =>
                {
                    b.HasOne("Swintake.domain.Campaigns.Campaign", "Campaign")
                        .WithMany()
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Swintake.domain.Candidates.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Swintake.domain.FilesToUpload.FileToUpload", "CV")
                        .WithOne()
                        .HasForeignKey("Swintake.domain.JobApplications.JobApplication", "CvGuid");

                    b.HasOne("Swintake.domain.FilesToUpload.FileToUpload", "MotivationLetter")
                        .WithOne()
                        .HasForeignKey("Swintake.domain.JobApplications.JobApplication", "MotivationLetterGuid");

                    b.HasOne("Swintake.domain.JobApplications.SelectionSteps.SelectionStep", "CurrentSelectionStep")
                        .WithMany()
                        .HasForeignKey("CurrentSelectionStepJobApplicationId", "CurrentSelectionStepDescription");
                });

            modelBuilder.Entity("Swintake.domain.JobApplications.SelectionSteps.SelectionStep", b =>
                {
                    b.HasOne("Swintake.domain.JobApplications.JobApplication", "JobApplication")
                        .WithMany("SelectionSteps")
                        .HasForeignKey("JobApplicationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Swintake.domain.Users.User", b =>
                {
                    b.OwnsOne("Swintake.domain.Users.UserSecurity", "UserSecurity", b1 =>
                        {
                            b1.Property<Guid?>("UserId");

                            b1.Property<string>("AppliedSalt")
                                .HasColumnName("AppliedSalt");

                            b1.Property<string>("PasswordHashedAndSalted")
                                .HasColumnName("PasswordHashed");

                            b1.ToTable("Users");

                            b1.HasOne("Swintake.domain.Users.User")
                                .WithOne("UserSecurity")
                                .HasForeignKey("Swintake.domain.Users.UserSecurity", "UserId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.HasData(
                                new { UserId = new Guid("412cd99b-26a1-4784-8e3e-ecbc63ffc3de"), AppliedSalt = "NgBFEGiYlnKAVlAkBj6Qkg==", PasswordHashedAndSalted = "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                                new { UserId = new Guid("6ba2098b-7e1d-4d25-af47-f50f43c4e5b0"), AppliedSalt = "rODZhnBsLGRP908sBZiXzg==", PasswordHashedAndSalted = "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                            );
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
