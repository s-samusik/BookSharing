using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class fixRentLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_RentLocations_RentLocationDtoId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "RentLocationDtoId",
                table: "Books",
                newName: "RentLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_RentLocationDtoId",
                table: "Books",
                newName: "IX_Books_RentLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_RentLocations_RentLocationId",
                table: "Books",
                column: "RentLocationId",
                principalTable: "RentLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_RentLocations_RentLocationId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "RentLocationId",
                table: "Books",
                newName: "RentLocationDtoId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_RentLocationId",
                table: "Books",
                newName: "IX_Books_RentLocationDtoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_RentLocations_RentLocationDtoId",
                table: "Books",
                column: "RentLocationDtoId",
                principalTable: "RentLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
