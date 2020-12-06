using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class RentLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentLocations_RentLocationAddresses_RentLocationAddressId",
                table: "RentLocations");

            migrationBuilder.DropTable(
                name: "RentLocationAddresses");

            migrationBuilder.DropIndex(
                name: "IX_RentLocations_RentLocationAddressId",
                table: "RentLocations");

            migrationBuilder.DropColumn(
                name: "RentLocationAddressId",
                table: "RentLocations");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Building",
                table: "RentLocations",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RentLocations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "RentLocations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "RentLocations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Building",
                table: "RentLocations");

            migrationBuilder.DropColumn(
                name: "City",
                table: "RentLocations");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "RentLocations");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "RentLocations");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RentLocationAddressId",
                table: "RentLocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RentLocationAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Building = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentLocationAddresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentLocations_RentLocationAddressId",
                table: "RentLocations",
                column: "RentLocationAddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RentLocations_RentLocationAddresses_RentLocationAddressId",
                table: "RentLocations",
                column: "RentLocationAddressId",
                principalTable: "RentLocationAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
