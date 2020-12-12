using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class Fix2_Entity_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_RentLocations_RentLocationId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RentLocationId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RentLocationId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentLocationId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RentLocationId",
                table: "Users",
                column: "RentLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RentLocations_RentLocationId",
                table: "Users",
                column: "RentLocationId",
                principalTable: "RentLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
