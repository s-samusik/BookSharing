using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class AddRentLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "RentLocations",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        Building = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RentLocations", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentLocations");
        }
    }
}
