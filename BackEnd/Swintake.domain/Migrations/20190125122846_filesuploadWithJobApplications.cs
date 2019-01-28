using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class filesuploadWithJobApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("7d1ad9ab-b383-4a16-a26e-7f48fc099672"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("c14201ea-f85e-4e8d-8bbe-942f53bdfeb2"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("ce9dd460-3b7c-401e-ba2b-368e2a8bb11d"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("38f64d79-db9c-43bc-920c-fa4b962ee295"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("54301284-9186-47ac-a42a-a0c2902c7a60"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("b730830f-2630-45b6-98d3-b363ef4afbdd"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("fe0a8fc4-10db-4f4e-a4b7-663c4dba777f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("06fa975b-4c67-4463-b424-13e8a4da7c4a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ebf90813-23ed-4e6f-adf3-b43a02b2ef14"));

            migrationBuilder.AddColumn<Guid>(
                name: "CvGuid",
                table: "JobApplications",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MotivationLetterGuid",
                table: "JobApplications",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobApplicationId",
                table: "Files",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("3ca351a3-5aa5-4daa-b285-36f64e08dc7d"), new DateTime(2019, 3, 25, 13, 28, 46, 173, DateTimeKind.Local), "mixed", "max 8 candidates", "dotnet class 2019", new DateTime(2019, 2, 25, 13, 28, 46, 174, DateTimeKind.Local), 1 },
                    { new Guid("517b5e34-2ae9-4467-896d-ce4cbe474af4"), new DateTime(2019, 1, 25, 13, 28, 46, 175, DateTimeKind.Local), "CM", "at cm location", "Java academy 2019", new DateTime(2019, 1, 25, 13, 28, 46, 175, DateTimeKind.Local), 1 },
                    { new Guid("aed64cf9-e6fd-4cb8-93e2-953389a287fb"), new DateTime(2019, 3, 16, 13, 28, 46, 175, DateTimeKind.Local), "open for all", "", "Short javascript bootcamp", new DateTime(2019, 2, 4, 13, 28, 46, 175, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("235cffb9-331f-40be-b5d0-473cfa5cd9f5"), "", "gwen.jamroziak@cegeka.com", "Gwen", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472020406" },
                    { new Guid("7907e3f4-4892-47e1-abfe-28fe150b8775"), "", "caroline.callens@cegeka.com", "Caroline", "carolinecallens", "Callens", "carolinecallens", "0472030507" },
                    { new Guid("d74190f2-cdc5-4642-a968-e2384362f64e"), "", "siene.dekeyser@cegeka.com", "Siene", "sienedekeyser", "Dekeyser", "sienedekeyser", "0472040608" },
                    { new Guid("95a60e2b-aaf6-4bf1-aa24-c7d4f2bf0a2b"), "", "luc.verhoeven@carglass.be", "Luc", "lucverhoeven", "Verhoeven", "lucverhoeven", "0472050403" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("412cd99b-26a1-4784-8e3e-ecbc63ffc3de"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("6ba2098b-7e1d-4d25-af47-f50f43c4e5b0"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CvGuid",
                table: "JobApplications",
                column: "CvGuid",
                unique: true,
                filter: "[CvGuid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_MotivationLetterGuid",
                table: "JobApplications",
                column: "MotivationLetterGuid",
                unique: true,
                filter: "[MotivationLetterGuid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Files_CvGuid",
                table: "JobApplications",
                column: "CvGuid",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Files_MotivationLetterGuid",
                table: "JobApplications",
                column: "MotivationLetterGuid",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Files_CvGuid",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Files_MotivationLetterGuid",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_CvGuid",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_MotivationLetterGuid",
                table: "JobApplications");

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("3ca351a3-5aa5-4daa-b285-36f64e08dc7d"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("517b5e34-2ae9-4467-896d-ce4cbe474af4"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("aed64cf9-e6fd-4cb8-93e2-953389a287fb"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("235cffb9-331f-40be-b5d0-473cfa5cd9f5"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("7907e3f4-4892-47e1-abfe-28fe150b8775"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("95a60e2b-aaf6-4bf1-aa24-c7d4f2bf0a2b"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("d74190f2-cdc5-4642-a968-e2384362f64e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("412cd99b-26a1-4784-8e3e-ecbc63ffc3de"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6ba2098b-7e1d-4d25-af47-f50f43c4e5b0"));

            migrationBuilder.DropColumn(
                name: "CvGuid",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "MotivationLetterGuid",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                table: "Files");

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("c14201ea-f85e-4e8d-8bbe-942f53bdfeb2"), new DateTime(2019, 3, 25, 11, 37, 31, 605, DateTimeKind.Local), "mixed", "max 8 candidates", "dotnet class 2019", new DateTime(2019, 2, 25, 11, 37, 31, 606, DateTimeKind.Local), 1 },
                    { new Guid("ce9dd460-3b7c-401e-ba2b-368e2a8bb11d"), new DateTime(2019, 1, 25, 11, 37, 31, 608, DateTimeKind.Local), "CM", "at cm location", "Java academy 2019", new DateTime(2019, 1, 25, 11, 37, 31, 608, DateTimeKind.Local), 1 },
                    { new Guid("7d1ad9ab-b383-4a16-a26e-7f48fc099672"), new DateTime(2019, 3, 16, 11, 37, 31, 608, DateTimeKind.Local), "open for all", "", "Short javascript bootcamp", new DateTime(2019, 2, 4, 11, 37, 31, 608, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("b730830f-2630-45b6-98d3-b363ef4afbdd"), "", "gwen.jamroziak@cegeka.com", "Gwen", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472020406" },
                    { new Guid("38f64d79-db9c-43bc-920c-fa4b962ee295"), "", "caroline.callens@cegeka.com", "Caroline", "carolinecallens", "Callens", "carolinecallens", "0472030507" },
                    { new Guid("54301284-9186-47ac-a42a-a0c2902c7a60"), "", "siene.dekeyser@cegeka.com", "Siene", "sienedekeyser", "Dekeyser", "sienedekeyser", "0472040608" },
                    { new Guid("fe0a8fc4-10db-4f4e-a4b7-663c4dba777f"), "", "luc.verhoeven@carglass.be", "Luc", "lucverhoeven", "Verhoeven", "lucverhoeven", "0472050403" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("ebf90813-23ed-4e6f-adf3-b43a02b2ef14"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("06fa975b-4c67-4463-b424-13e8a4da7c4a"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });
        }
    }
}
