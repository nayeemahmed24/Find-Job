using Microsoft.EntityFrameworkCore.Migrations;

namespace InterviewBoard.Migrations
{
    public partial class message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messege_AspNetUsers_user",
                table: "Messege");

            migrationBuilder.DropIndex(
                name: "IX_Messege_user",
                table: "Messege");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Messege");

            migrationBuilder.DropColumn(
                name: "user",
                table: "Messege");

            migrationBuilder.AddColumn<string>(
                name: "ReciverUsername",
                table: "Messege",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderUsername",
                table: "Messege",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "senduser",
                table: "Messege",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messege_senduser",
                table: "Messege",
                column: "senduser");

            migrationBuilder.AddForeignKey(
                name: "FK_Messege_AspNetUsers_senduser",
                table: "Messege",
                column: "senduser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messege_AspNetUsers_senduser",
                table: "Messege");

            migrationBuilder.DropIndex(
                name: "IX_Messege_senduser",
                table: "Messege");

            migrationBuilder.DropColumn(
                name: "ReciverUsername",
                table: "Messege");

            migrationBuilder.DropColumn(
                name: "SenderUsername",
                table: "Messege");

            migrationBuilder.DropColumn(
                name: "senduser",
                table: "Messege");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Messege",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user",
                table: "Messege",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messege_user",
                table: "Messege",
                column: "user");

            migrationBuilder.AddForeignKey(
                name: "FK_Messege_AspNetUsers_user",
                table: "Messege",
                column: "user",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
