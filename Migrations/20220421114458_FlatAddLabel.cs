using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment_Management.Migrations
{
    public partial class FlatAddLabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlatLabel",
                table: "Flat",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_FlatLabel",
                table: "Flat",
                column: "FlatLabel",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flat_FlatLabel",
                table: "Flat");

            migrationBuilder.DropColumn(
                name: "FlatLabel",
                table: "Flat");
        }
    }
}
