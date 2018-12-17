using System;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.BusinessLayer.Entities.Permissions;
using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.BusinessLayer.Entities.Users;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthenticationService.DataLayer.Context
{
    public class AuthenticationServiceContext : DbContext
    {
        public AuthenticationServiceContext()
        {
        }

        public AuthenticationServiceContext(DbContextOptions<AuthenticationServiceContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure if it hasn't been configured yet. We are probably
            // running unit tests if it hasn't been configured.
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<AuthenticationLog> AuthenticationLogs { get; set; }
    }
}
