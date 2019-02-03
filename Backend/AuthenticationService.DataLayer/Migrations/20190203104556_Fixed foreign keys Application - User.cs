using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataLayer.Migrations
{
    public partial class FixedforeignkeysApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_UserID",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_UserID",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("fdedbb7b-cfc5-4765-8796-1d5da0139e05"));

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Applications");

            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    ApplicationID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => new { x.ApplicationID, x.UserID });
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Applications_ApplicationID",
                        column: x => x.ApplicationID,
                        principalTable: "Applications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUsers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("4d3e46ee-0d75-4d92-9451-bdd67d7e1dfd"), "Super admin" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_UserID",
                table: "ApplicationUsers",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUsers");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("4d3e46ee-0d75-4d92-9451-bdd67d7e1dfd"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Applications",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("fdedbb7b-cfc5-4765-8796-1d5da0139e05"), "Super admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserID",
                table: "Applications",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_UserID",
                table: "Applications",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
