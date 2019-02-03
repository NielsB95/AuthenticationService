using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataLayer.Migrations
{
    public partial class AddedApplicationCodetoAuthenticationLogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("4d3e46ee-0d75-4d92-9451-bdd67d7e1dfd"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationCode",
                table: "AuthenticationLogs",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("964c171e-0803-46f2-9bbc-419e60e152a2"), "Super admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ApplicationCode",
                table: "Applications",
                column: "ApplicationCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Applications_ApplicationCode",
                table: "Applications");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("964c171e-0803-46f2-9bbc-419e60e152a2"));

            migrationBuilder.DropColumn(
                name: "ApplicationCode",
                table: "AuthenticationLogs");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("4d3e46ee-0d75-4d92-9451-bdd67d7e1dfd"), "Super admin" });
        }
    }
}
