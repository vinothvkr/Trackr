using Microsoft.EntityFrameworkCore.Migrations;

namespace Trackr.Infrastructure.Migrations
{
    public partial class AddIssueTypeIdToIssueModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: "2aa88db3-ff9d-4296-a163-cd4906b30b14");

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: "e4f035bc-8b43-4bf5-b420-4ce63faf093a");

            migrationBuilder.AddColumn<string>(
                name: "IssueTypeId",
                table: "Issues",
                nullable: true);

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { "c2028ff9-9143-4a64-9ac8-763f61357305", "Bug" });

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { "e085a41b-0205-44d4-b86f-6ac09ef8b960", "Feature" });

            migrationBuilder.CreateIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_IssueTypes_IssueTypeId",
                table: "Issues",
                column: "IssueTypeId",
                principalTable: "IssueTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_IssueTypes_IssueTypeId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_IssueTypeId",
                table: "Issues");

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: "c2028ff9-9143-4a64-9ac8-763f61357305");

            migrationBuilder.DeleteData(
                table: "IssueTypes",
                keyColumn: "Id",
                keyValue: "e085a41b-0205-44d4-b86f-6ac09ef8b960");

            migrationBuilder.DropColumn(
                name: "IssueTypeId",
                table: "Issues");

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { "2aa88db3-ff9d-4296-a163-cd4906b30b14", "Bug" });

            migrationBuilder.InsertData(
                table: "IssueTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { "e4f035bc-8b43-4bf5-b420-4ce63faf093a", "Feature" });
        }
    }
}
