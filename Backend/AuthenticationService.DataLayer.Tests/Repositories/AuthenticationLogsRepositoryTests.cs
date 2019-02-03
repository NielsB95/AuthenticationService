using System;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationService.DataLayer.Tests.Repositories
{
	[TestClass]
	public class AuthenticationLogsRepositoryTests
	{
		private AuthenticationServiceContext context;
		private AuthenticationLogRepository authenticationLogRepository;

		private User user = new User() { ID = Guid.NewGuid(), Firstname = "John" };
		private Guid applicationid = Guid.NewGuid();

		[TestInitialize]
		public void Initialize()
		{
			context = TestContext.CreateContext();
			context.Add(user);
			context.Add(new Application() { ID = applicationid, Name = "Authentication service" });

			context.Add(new AuthenticationLog() { ApplicationID = applicationid, User = user });
			context.SaveChanges();

			authenticationLogRepository = new AuthenticationLogRepository(context);
		}

		[TestMethod]
		public async Task GetAllTest()
		{
			var result = await authenticationLogRepository.GetAll();
			Assert.AreEqual(1, result.Count);

			var firstLog = result.First();
			Assert.IsNotNull(firstLog.Application);
			Assert.AreEqual("Authentication service", firstLog.Application.Name);

			Assert.IsNotNull(firstLog.User);
			Assert.AreEqual("John", firstLog.User.Firstname);
		}
	}
}
