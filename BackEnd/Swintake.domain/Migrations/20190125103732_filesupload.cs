using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class filesupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("717d8747-dc4f-4655-99f4-ec936a4afbc4"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("d5c5b85d-feb7-4f4a-b60a-f09525bd0553"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("f024fe5d-c994-48df-8849-1eb513049b71"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("054d5899-a803-499e-b5cb-ea2fe1a99b6c"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("5fc97819-fe50-4b3c-a913-c089e1ab4f77"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("78688585-ea60-413a-bfff-e4ede781200b"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("d4ebff88-7319-453a-849d-a0f726748432"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a79fac29-f3e2-4640-b686-97eb1bd62ae4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d7590554-e931-4e2f-98ab-c223d94cdef2"));

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Filetype = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    FileContent = table.Column<string>(nullable: true),
                    UploadedFileContent = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

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
        }
    }
}
