using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationService.DataLayer.Tests.Repositories
{
    [TestClass]
    public class RoleRepositoryTests
    {
        private AuthenticationServiceContext context;
        private RoleRepository roleRepository;

        [TestInitialize]
        public void Initialize()
        {
            context = TestContext.CreateContext();
            context.Add(new Role() { Name = "Super admin" });
            context.SaveChanges();
            roleRepository = new RoleRepository(context);
        }

        [TestMethod]
        public void GetSuperAdmin_NotNull_Test()
        {
            var superAdmin = roleRepository.GetSuperAdmin();
            Assert.IsNotNull(superAdmin);
        }

        [TestMethod]
        public void GetSuperAdmin_HasCorrectName_Test()
        {
            var superAdmin = roleRepository.GetSuperAdmin();
            Assert.AreEqual("Super admin", superAdmin.Name);
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.RemoveRange(context.Roles);
            context.SaveChanges();
        }
    }
}
