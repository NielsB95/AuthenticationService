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

			context.Add(new User() { Firstname = "John", Username = "johnny" });
			context.Add(new User() { Firstname = "Jane", Username = "jane" });
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

		[TestCleanup]
		public void CleanUp()
		{
			context.RemoveRange(context.Users);
			context.SaveChanges();
		}
	}
}
