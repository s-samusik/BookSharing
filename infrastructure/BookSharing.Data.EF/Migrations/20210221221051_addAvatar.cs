using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class addAvatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Avatar",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");
        }
    }
}
