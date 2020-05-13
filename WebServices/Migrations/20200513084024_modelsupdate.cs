using Microsoft.EntityFrameworkCore.Migrations;

namespace WebServices.Migrations
{
    public partial class modelsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Post",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Post_User",
                table: "Post",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_AspNetUsers_User",
                table: "Post",
                column: "User",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_AspNetUsers_User",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_User",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Post");
        }
    }
}
