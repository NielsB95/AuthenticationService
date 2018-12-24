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
    [Migration("20181224101422_Super admin seed")]
    partial class Superadminseed
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

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<Guid?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.AuthenticationLogs.AuthenticationLog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

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
                            ID = new Guid("9ecab798-868b-4bc5-ad8b-003657e2a1e2"),
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

            modelBuilder.Entity("AuthenticationService.BusinessLayer.Entities.Applications.Application", b =>
                {
                    b.HasOne("AuthenticationService.BusinessLayer.Entities.Users.User")
                        .WithMany("Applications")
                        .HasForeignKey("UserID");
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
