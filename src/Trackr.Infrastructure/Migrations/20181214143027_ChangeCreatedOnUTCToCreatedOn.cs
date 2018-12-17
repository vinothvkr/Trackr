using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackr.Infrastructure.Migrations
{
    public partial class ChangeCreatedOnUTCToCreatedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOnUTC",
                table: "Projects",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUTC",
                table: "Issues",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "CreatedOnUTC",
                table: "Comments",
                newName: "CreatedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Projects",
                newName: "CreatedOnUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Issues",
                newName: "CreatedOnUTC");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Comments",
                newName: "CreatedOnUTC");
        }
    }
}
