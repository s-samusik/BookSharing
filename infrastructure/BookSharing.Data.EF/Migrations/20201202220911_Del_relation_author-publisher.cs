using Microsoft.EntityFrameworkCore.Migrations;

namespace BookSharing.Data.EF.Migrations
{
    public partial class Del_relation_authorpublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Publishers_PublisherId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_PublisherId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Authors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_PublisherId",
                table: "Authors",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Publishers_PublisherId",
                table: "Authors",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
