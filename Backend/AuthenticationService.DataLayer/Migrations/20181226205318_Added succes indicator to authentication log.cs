﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataLayer.Migrations
{
    public partial class Addedsuccesindicatortoauthenticationlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Successful",
                table: "AuthenticationLogs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Successful",
                table: "AuthenticationLogs");
        }
    }
}
