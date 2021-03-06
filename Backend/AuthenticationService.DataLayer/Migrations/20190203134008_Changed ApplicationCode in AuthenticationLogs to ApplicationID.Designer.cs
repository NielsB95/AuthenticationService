﻿// <auto-generated />
using System;
using AuthenticationService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AuthenticationService.DataLayer.Migrations
{
    [DbContext(typeof(AuthenticationServiceContext))]
    [Migration("20190203134008_Changed ApplicationCode in AuthenticationLogs to ApplicationID")]
    partial class ChangedApplicationCodeinAuthenticationLogstoApplicationID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Applications.Application", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationCode")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ApplicationCode")
                        .IsUnique();

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Applications.ApplicationUser", b =>
                {
                    b.Property<Guid>("ApplicationID");

                    b.Property<Guid>("UserID");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd();

                    b.HasKey("ApplicationID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("ApplicationUsers");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.AuthenticationLogs.AuthenticationLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationID");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Successful");

                    b.Property<Guid?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("AuthenticationLogs");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Permissions.Permission", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("RoleID");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Roles.Role", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d9d77f1a-d803-4d15-bdd6-21d623291ed8"),
                            Name = "Super admin"
                        });
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Users.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<Guid?>("RoleID");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Applications.ApplicationUser", b =>
                {
                    b.HasOne("AuthenticationService.BusinessLayer.Entities.Applications.Application", "Application")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("ApplicationID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AuthenticationService.BusinessLayer.Entities.Users.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.AuthenticationLogs.AuthenticationLog", b =>
                {
                    b.HasOne("AuthenticationService.BusinessLayer.Entities.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Permissions.Permission", b =>
                {
                    b.HasOne("AuthenticationService.BusinessLayer.Entities.Roles.Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleID");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Users.User", b =>
                {
                    b.HasOne("AuthenticationService.BusinessLayer.Entities.Roles.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");
                });
#pragma warning restore 612, 618
        }
    }
}
