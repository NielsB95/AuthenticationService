using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataLayer.Migrations
{
    public partial class AddedApplicationCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("dd1c035a-6ef9-435c-b67d-f2d739cb9eae"));

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationCode",
                table: "Applications",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("fdedbb7b-cfc5-4765-8796-1d5da0139e05"), "Super admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("fdedbb7b-cfc5-4765-8796-1d5da0139e05"));

            migrationBuilder.DropColumn(
                name: "ApplicationCode",
                table: "Applications");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("dd1c035a-6ef9-435c-b67d-f2d739cb9eae"), "Super admin" });
        }
    }
}
