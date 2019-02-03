using System;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationService.DataLayer.Tests.Repositories
{
	[TestClass]
	public class ApplicationUserRepositoryTests
	{
		private AuthenticationServiceContext context;
		private ApplicationUserRepository applicationUserRepository;

		private Guid userid = Guid.NewGuid();
		private Guid applicationID1 = Guid.NewGuid();
		private Guid applicationID2 = Guid.NewGuid();
		private Guid applicationCode1 = Guid.NewGuid();
		private Guid applicationCode2 = Guid.NewGuid();


		[TestInitialize]
		public void Initialze()
		{
			context = TestContext.CreateContext();
			context.Add(new User() { ID = userid });
			context.Add(new Application() { ID = applicationID1, Name = "Authentication service", ApplicationCode = applicationCode1 });
			context.Add(new Application() { ID = applicationID2, Name = "Product service", ApplicationCode = applicationCode2 });
			context.Add(new ApplicationUser() { UserID = userid, ApplicationID = applicationID1 });
			context.SaveChanges();

			applicationUserRepository = new ApplicationUserRepository(context);
		}

		[TestMethod]
		public async Task UserHasApplicationRightsTest()
		{
			var isAuthorized = await applicationUserRepository.IsAuthorized(userid, applicationCode1);
			Assert.IsTrue(isAuthorized);
		}

		[TestMethod]
		public async Task UserHasNoApplicationRightsTest()
		{
			var isAuthorized = await applicationUserRepository.IsAuthorized(userid, applicationCode2);
			Assert.IsFalse(isAuthorized);
		}

		[TestCleanup]
		public void Cleanup()
		{
			context.RemoveRange(context.Users);
			context.RemoveRange(context.Applications);
			context.RemoveRange(context.ApplicationUsers);
			context.SaveChanges();
		}
	}
}
