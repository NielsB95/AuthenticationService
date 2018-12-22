using AuthenticationService.Api.Controllers;
using AuthenticationService.BusinessLayer.Entities.Roles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Tests.Controllers
{
	[TestClass]
	public class RoleControllerTests : ApiTests
	{
		private IRoleRepository roleRepository;
		private RoleController roleController;

		[TestInitialize]
		public void Initialize()
		{
			var mockRepo = new Mock<IRoleRepository>();
			mockRepo.Setup(x => x.GetAll()).ReturnsAsync(GetRoles());
			roleRepository = mockRepo.Object;

			roleController = new RoleController(roleRepository);
		}

		[TestMethod]
		public async Task GET_GetRoles()
		{
			var response = await roleController.GetRoles();
			var roles = GetResult(response);

			Assert.AreEqual(2, roles.Count);
		}

		private IList<Role> GetRoles()
		{
			return new List<Role>() {
				new Role()
				{
					Name = "Admin"
				},
				new Role()
				{
					Name = "Customer"
				}
			};
		}
	}
}
