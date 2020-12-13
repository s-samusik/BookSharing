using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class fix_book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Publishers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Authors",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Publishers",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "Nickname");
        }
    }
}
