using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment_Management.Migrations
{
    public partial class FlatAssignmentRemoveID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ID",
                table: "FlatAssignment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "FlatAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
