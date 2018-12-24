using System.Threading.Tasks;
using AuthenticationService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.DataLayer.Tests
{
    public static class TestContext
    {
        public static AuthenticationServiceContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<AuthenticationServiceContext>()
                     .UseInMemoryDatabase("UnitTestDatabase")
                     .Options;

            var context = new AuthenticationServiceContext(options);
            return context;
        }
    }
}
