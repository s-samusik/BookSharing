using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class fix_userType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_Name",
                table: "UserTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTypes_Name",
                table: "UserTypes");
        }
    }
}
