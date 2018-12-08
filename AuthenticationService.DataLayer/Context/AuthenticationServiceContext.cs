using System;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.Permissions;
using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.BusinessLayer.Entities.Users;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.DataLayer.Context
{
    public class AuthenticationServiceContext : DbContext
    {
        protected AuthenticationServiceContext()
        {
        }

        public AuthenticationServiceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Permission> Permissions { get; set; }
    }
}
