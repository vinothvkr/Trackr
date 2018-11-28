using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackr.Infrastructure.Migrations
{
    public partial class IssueModelChangeBodyToDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Body",
                table: "Issues",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Issues",
                newName: "Body");
        }
    }
}
