using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataLayer.Migrations
{
    public partial class ChangedApplicationCodeinAuthenticationLogstoApplicationID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("964c171e-0803-46f2-9bbc-419e60e152a2"));

            migrationBuilder.RenameColumn(
                name: "ApplicationCode",
                table: "AuthenticationLogs",
                newName: "ApplicationID");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("d9d77f1a-d803-4d15-bdd6-21d623291ed8"), "Super admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d9d77f1a-d803-4d15-bdd6-21d623291ed8"));

            migrationBuilder.RenameColumn(
                name: "ApplicationID",
                table: "AuthenticationLogs",
                newName: "ApplicationCode");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("964c171e-0803-46f2-9bbc-419e60e152a2"), "Super admin" });
        }
    }
}
