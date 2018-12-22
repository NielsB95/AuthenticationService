using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.Api.Controllers;
using AuthenticationService.BusinessLayer.Entities.Permissions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AuthenticationService.Api.Tests.Controllers
{
    [TestClass]
    public class PermissionControllerTests : ApiTests
    {
        private IPermissionRepository permissionRepository;
        private PermissionController permissionController;

        [TestInitialize]
        public void Initialize()
        {
            var mockRepo = new Mock<IPermissionRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(GetPermissions());
            permissionRepository = mockRepo.Object;

            permissionController = new PermissionController(permissionRepository);
        }

        [TestMethod]
        public async Task GET_GetAllTest()
        {
            var response = await permissionController.GetPermissions();
            var permissions = GetResult(response);

            Assert.AreEqual(2, permissions.Count);
        }

        /// <summary>
        /// Creates a test set for permissions.
        /// </summary>
        /// <returns></returns>
        private IList<Permission> GetPermissions()
        {
            return new List<Permission>()
            {
                new Permission()
                {
                    Name = "Admin"
                },
                new Permission()
                {
                    Name ="Customer"
                }
            };
        }
    }
}
