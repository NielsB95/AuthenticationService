using System;
using AuthenticationService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.DataLayer.Tests
{
    public static class TestContext
    {
        public static AuthenticationServiceContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AuthenticationServiceContext>()
                     .UseInMemoryDatabase(databaseName: "UnitTestDatabase")
                     .Options;

            return new AuthenticationServiceContext(options);
        }
    }
}
