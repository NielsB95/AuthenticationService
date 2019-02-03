using System;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationService.DataLayer.Tests.Repositories
{
	[TestClass]
	public class ApplicationRepositoryTests
	{
		private AuthenticationServiceContext context;
		private ApplicationRepository applicationRepository;
		private Guid applicationCode1 = Guid.NewGuid();
		private Guid applicationCode2 = Guid.NewGuid();

		public ApplicationRepositoryTests()
		{
			context = TestContext.CreateContext();
			context.Add(new Application() { ID = Guid.NewGuid(), Name = "Authentication service", ApplicationCode = applicationCode1 });
			context.Add(new Application() { ID = Guid.NewGuid(), Name = "Product service", ApplicationCode = applicationCode2 });
			context.SaveChanges();
			applicationRepository = new ApplicationRepository(context);
		}

		[TestMethod]
		public async Task GetByApplicationCodeTest()
		{
			var authenticationService = await applicationRepository.GetByApplicationCode(applicationCode1);
			Assert.AreEqual("Authentication service", authenticationService.Name);

			var productService = await applicationRepository.GetByApplicationCode(applicationCode2);
			Assert.AreEqual("Product service", productService.Name);
		}

		[TestMethod]
		public async Task GetByApplicationCodeNullResultTest()
		{
			var result = await applicationRepository.GetByApplicationCode(Guid.Empty);
			Assert.IsNull(result);
		}

		[TestCleanup]
		public void Cleanup()
		{
			context.RemoveRange(context.Applications);
			context.SaveChanges();
		}
	}
}