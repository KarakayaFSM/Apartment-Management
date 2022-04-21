using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment_Management.Migrations
{
    public partial class UserRemoveManagerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
