using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackr.Infrastructure.Migrations
{
    public partial class CreateAndSeedIssueTypeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IssueTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { "2aa88db3-ff9d-4296-a163-cd4906b30b14", "Bug" });

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { "e4f035bc-8b43-4bf5-b420-4ce63faf093a", "Feature" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueTypes");
        }
    }
}
