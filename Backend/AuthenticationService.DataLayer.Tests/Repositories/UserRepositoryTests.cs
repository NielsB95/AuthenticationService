using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace AuthenticationService.DataLayer.Tests.Repositories
{
    [TestClass]
    public class UserRepositoryTests
    {
        private AuthenticationServiceContext context;

        [TestInitialize]
        public void Initialize()
        {
            context = TestContext.CreateContext();

            var admin = context.Add(new Role() { Name = "Admin" }).Entity;
            var user = context.Add(new Role() { Name = "User" }).Entity;

            context.Add(new User() { Firstname = "John", Username = "johnny", Role = admin });
            context.Add(new User() { Firstname = "Jane", Username = "jane", Role = user });
            context.Add(new User() { Firstname = "Joe", Username = "joe" });

            context.SaveChanges();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByUserNameNullTest()
        {
            var repo = new UserRepository(context);
            var error = await repo.GetByUsername(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetByUserNameEmptyStringTest()
        {
            var repo = new UserRepository(context);
            var error = await repo.GetByUsername("");
        }

        [TestMethod]
        public async Task GetByUserNameTest()
        {
            var repo = new UserRepository(context);
            var john = await repo.GetByUsername("johnny");

            Assert.AreEqual("John", john.Firstname);
        }

        [TestMethod]
        public async Task GetByUserNameUpperCaseTest()
        {
            var repo = new UserRepository(context);
            var john = await repo.GetByUsername("JOHNNY");

            Assert.AreEqual("John", john.Firstname);
        }

        [TestMethod]
        public async Task GetByUserNameIncludesAdminRoleTest()
        {
            var repo = new UserRepository(context);
            var john = await repo.GetByUsername("johnny");

            Assert.AreEqual("Admin", john.Role.Name);
        }

        [TestMethod]
        public async Task GetByUserNameIncludesUserRoleTest()
        {
            var repo = new UserRepository(context);
            var jane = await repo.GetByUsername("jane");

            Assert.AreEqual("User", jane.Role.Name);
        }

        [TestMethod]
        public async Task GetByUserNameWithoutRoleTest()
        {
            var repo = new UserRepository(context);
            var joe = await repo.GetByUsername("joe");

            Assert.IsNull(joe.Role);
        }

        [TestMethod]
        public async Task GetByUsernameUnknownTest()
        {
            var repo = new UserRepository(context);
            var unkown = await repo.GetByUsername("Unknown");

            Assert.IsNull(unkown);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.RemoveRange(context.Users);
            context.RemoveRange(context.Roles);
            context.SaveChanges();
        }
    }
}
