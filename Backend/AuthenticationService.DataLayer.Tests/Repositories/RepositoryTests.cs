using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.DataLayer.Tests.Repositories
{
    [TestClass]
    public class RepositoryTests
    {
        private AuthenticationServiceContext context;

        [TestInitialize]
        public void Initialze()
        {
            context = TestContext.CreateContext();
            context.Add(new Role() { Name = "Admin" });
            context.Add(new Role() { Name = "Customer" });
            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            context.RemoveRange(context.Roles);
            context.SaveChanges();
        }

        [TestMethod]
        public async Task GetAllTest()
        {
            var repo = new RoleRepository(context);
            var roles = await repo.GetAll();

            Assert.AreEqual(2, roles.Count);
        }

        [TestMethod]
        public async Task AddTest()
        {
            var repo = new RoleRepository(context);
            var roles = await repo.GetAll();
            Assert.AreEqual(2, context.Roles.Count());

            await repo.Add(new Role() { Name = "Moderator" });

            Assert.AreEqual(3, context.Roles.Count());
            Assert.IsTrue(context.Roles.Select(x => x.Name).Contains("Moderator"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task AddNullTest()
        {
            var repo = new RoleRepository(context);
            await repo.Add(null);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            var repo = new RoleRepository(context);

            var role = context.Roles.Where(x => x.Name == "Admin").First();
            role.Name = "Super admin";

            await repo.Update(role);

            // Get a list of all the role names.
            var names = context.Roles.Select(x => x.Name).ToList();

            // Admin shouldn't be there anymore
            Assert.IsFalse(names.Contains("Admin"));

            // .. and it should be changed to Super admin.
            Assert.IsTrue(names.Contains("Super admin"));
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            // Check the curent number of roles.
            Assert.AreEqual(2, context.Roles.Count());

            // Get the admin role so we can delete it.
            var repo = new RoleRepository(context);
            var role = context.Roles.Where(x => x.Name == "Admin").First();

            await repo.Delete(role);

            // Admin shouldn't be there anymore
            Assert.AreEqual(1, context.Roles.Count());
        }
    }
}
