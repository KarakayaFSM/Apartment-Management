using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment_Management.Migrations
{
    public partial class FlatRemoveUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flat_User_UserID",
                table: "Flat");

            migrationBuilder.DropIndex(
                name: "IX_Flat_UserID",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Flat");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Flat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flat_UserID",
                table: "Flat",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flat_User_UserID",
                table: "Flat",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
