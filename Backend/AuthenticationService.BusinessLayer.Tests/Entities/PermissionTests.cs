using AuthenticationService.BusinessLayer.Entities.Permissions;
using AuthenticationService.BusinessLayer.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AuthenticationService.BusinessLayer.Tests.Entities
{
	[TestClass]
	public class PermissionTests
	{
		[TestMethod]
		public void ValidateInvalidPermission()
		{
			var permission = new Permission();

			var result = EntityValidator.Validate(permission);

			Assert.IsTrue(result.Any());

			var messages = result.Select(x => x.ErrorMessage);
			Assert.IsTrue(messages.Contains("The Name field is required."));
		}

		[TestMethod]
		public void ValidateValidApplication()
		{
			var permission = new Permission()
			{
				Name = "Product management"
			};

			var result = EntityValidator.Validate(permission);

			Assert.IsFalse(result.Any());
		}
	}
}
