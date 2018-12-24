using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataLayer.Migrations
{
    public partial class Superadminseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("9ecab798-868b-4bc5-ad8b-003657e2a1e2"), "Super admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("9ecab798-868b-4bc5-ad8b-003657e2a1e2"));
        }
    }
}
