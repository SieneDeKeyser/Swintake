using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class InitialSetupDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Client = table.Column<string>(maxLength: 60, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ClassStartDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: true),
                    LastName = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    GitHubUsername = table.Column<string>(maxLength: 100, nullable: true),
                    LinkedIn = table.Column<string>(maxLength: 200, nullable: true),
                    Comment = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHashed = table.Column<string>(nullable: true),
                    AppliedSalt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CampaignId = table.Column<Guid>(nullable: false),
                    CurrentSelectionStepJobApplicationId = table.Column<Guid>(nullable: true),
                    CurrentSelectionStepDescription = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplications_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SelectionStep",
                columns: table => new
                {
                    JobApplicationId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 90, nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionStep", x => new { x.JobApplicationId, x.Description });
                    table.ForeignKey(
                        name: "FK_SelectionStep_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("f024fe5d-c994-48df-8849-1eb513049b71"), new DateTime(2019, 2, 20, 13, 8, 16, 281, DateTimeKind.Local), "mixed", "max 8 candidates", "dotnet class 2019", new DateTime(2019, 1, 20, 13, 8, 16, 283, DateTimeKind.Local), 1 },
                    { new Guid("717d8747-dc4f-4655-99f4-ec936a4afbc4"), new DateTime(2018, 12, 20, 13, 8, 16, 286, DateTimeKind.Local), "CM", "at cm location", "Java academy 2019", new DateTime(2018, 12, 20, 13, 8, 16, 286, DateTimeKind.Local), 1 },
                    { new Guid("d5c5b85d-feb7-4f4a-b60a-f09525bd0553"), new DateTime(2019, 2, 8, 13, 8, 16, 286, DateTimeKind.Local), "open for all", "", "Short javascript bootcamp", new DateTime(2018, 12, 30, 13, 8, 16, 286, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("78688585-ea60-413a-bfff-e4ede781200b"), "", "gwen.jamroziak@cegeka.com", "Gwen", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472020406" },
                    { new Guid("054d5899-a803-499e-b5cb-ea2fe1a99b6c"), "", "caroline.callens@cegeka.com", "Caroline", "carolinecallens", "Callens", "carolinecallens", "0472030507" },
                    { new Guid("d4ebff88-7319-453a-849d-a0f726748432"), "", "siene.dekeyser@cegeka.com", "Siene", "sienedekeyser", "Dekeyser", "sienedekeyser", "0472040608" },
                    { new Guid("5fc97819-fe50-4b3c-a913-c089e1ab4f77"), "", "luc.verhoeven@carglass.be", "Luc", "lucverhoeven", "Verhoeven", "lucverhoeven", "0472050403" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("a79fac29-f3e2-4640-b686-97eb1bd62ae4"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("d7590554-e931-4e2f-98ab-c223d94cdef2"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CampaignId",
                table: "JobApplications",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CandidateId",
                table: "JobApplications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CurrentSelectionStepJobApplicationId_CurrentSelectionStepDescription",
                table: "JobApplications",
                columns: new[] { "CurrentSelectionStepJobApplicationId", "CurrentSelectionStepDescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_SelectionStep_CurrentSelectionStepJobApplicationId_CurrentSelectionStepDescription",
                table: "JobApplications",
                columns: new[] { "CurrentSelectionStepJobApplicationId", "CurrentSelectionStepDescription" },
                principalTable: "SelectionStep",
                principalColumns: new[] { "JobApplicationId", "Description" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Campaigns_CampaignId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Candidates_CandidateId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_SelectionStep_CurrentSelectionStepJobApplicationId_CurrentSelectionStepDescription",
                table: "JobApplications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "SelectionStep");

            migrationBuilder.DropTable(
                name: "JobApplications");
        }
    }
}
