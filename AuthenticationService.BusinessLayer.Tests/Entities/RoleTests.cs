using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.BusinessLayer.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AuthenticationService.BusinessLayer.Tests.Entities
{
	[TestClass]
	public class RoleTests
	{
		[TestMethod]
		public void ValidateInvalidRole()
		{
			var role = new Role();

			var result = EntityValidator.Validate(role);

			Assert.IsTrue(result.Any());

			var messages = result.Select(x => x.ErrorMessage);
			Assert.IsTrue(messages.Contains("The Name field is required."));
		}

		[TestMethod]
		public void ValidateValidRole()
		{
			var role = new Role()
			{
				Name = "Super admin"
			};

			var result = EntityValidator.Validate(role);

			Assert.IsFalse(result.Any());
		}
	}
}