using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apartment_Management.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Charge = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    PeriodDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Tckn = table.Column<string>(maxLength: 11, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    ManagerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BankCard",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CardHolderName = table.Column<string>(nullable: false),
                    CardNumber = table.Column<int>(nullable: false),
                    ExpireYear = table.Column<int>(nullable: false),
                    ExpireMonth = table.Column<int>(nullable: false),
                    CVV = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCard", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankCard_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flat",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlockCode = table.Column<string>(nullable: false),
                    IsFull = table.Column<bool>(nullable: false),
                    FlatSize = table.Column<string>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    DoorNum = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flat", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Flat_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Message_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Plate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vehicle_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlatAssignment",
                columns: table => new
                {
                    FlatID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatAssignment", x => new { x.FlatID, x.UserID });
                    table.ForeignKey(
                        name: "FK_FlatAssignment_Flat_FlatID",
                        column: x => x.FlatID,
                        principalTable: "Flat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlatAssignment_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodID = table.Column<int>(nullable: false),
                    InvoiceTypeID = table.Column<int>(nullable: false),
                    FlatID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoice_Flat_FlatID",
                        column: x => x.FlatID,
                        principalTable: "Flat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceType_InvoiceTypeID",
                        column: x => x.InvoiceTypeID,
                        principalTable: "InvoiceType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_Period_PeriodID",
                        column: x => x.PeriodID,
                        principalTable: "Period",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payment_Flat_FlatID",
                        column: x => x.FlatID,
                        principalTable: "Flat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankCard_UserID",
                table: "BankCard",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_UserID",
                table: "Flat",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Flat_BlockCode_DoorNum",
                table: "Flat",
                columns: new[] { "BlockCode", "DoorNum" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlatAssignment_FlatID",
                table: "FlatAssignment",
                column: "FlatID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlatAssignment_UserID",
                table: "FlatAssignment",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceTypeID",
                table: "Invoice",
                column: "InvoiceTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_PeriodID",
                table: "Invoice",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_FlatID_PeriodID_InvoiceTypeID",
                table: "Invoice",
                columns: new[] { "FlatID", "PeriodID", "InvoiceTypeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceType_Name",
                table: "InvoiceType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserID",
                table: "Message",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_FlatID",
                table: "Payment",
                column: "FlatID");

            migrationBuilder.CreateIndex(
                name: "IX_Period_Name",
                table: "Period",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_PhoneNumber",
                table: "User",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Tckn",
                table: "User",
                column: "Tckn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Plate",
                table: "Vehicle",
                column: "Plate",
                unique: true,
                filter: "[Plate] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_UserID",
                table: "Vehicle",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCard");

            migrationBuilder.DropTable(
                name: "FlatAssignment");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "InvoiceType");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "Flat");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
