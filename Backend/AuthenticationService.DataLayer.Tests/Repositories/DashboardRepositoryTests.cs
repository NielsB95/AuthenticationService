using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.DataLayer.Tests.Repositories
{
	[TestClass]
	public class DashboardRepositoryTests
	{
		private AuthenticationServiceContext context;
		private DateTime Yesterday = DateTime.Today.AddDays(-1);
		private DateTime DayBeforeYesterday = DateTime.Today.AddDays(-2);


		[TestInitialize]
		public void Initialze()
		{
			context = TestContext.CreateContext();

			// Add users
			context.Add(new User() { Firstname = "Jane", CreatedAt = DayBeforeYesterday });
			context.Add(new User() { Firstname = "John", CreatedAt = Yesterday });
			context.Add(new User() { Firstname = "Joe", CreatedAt = Yesterday });

			// Add logs
			context.Add(new AuthenticationLog() { CreatedAt = Yesterday });
			context.Add(new AuthenticationLog() { CreatedAt = Yesterday });
			context.Add(new AuthenticationLog() { CreatedAt = Yesterday });
			context.Add(new AuthenticationLog() { CreatedAt = DayBeforeYesterday });

			context.SaveChanges();
		}

		[TestCleanup]
		public void CleanUp()
		{
			context.RemoveRange(context.Users);
			context.RemoveRange(context.AuthenticationLogs);
			context.SaveChanges();
		}

		#region Amount of users
		[TestMethod]
		public async Task CheckDaysGetUsersFromDays()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUsersFromLastDays(7);

			Assert.AreEqual(8, result.Count);
		}

		[TestMethod]
		public async Task GetUsersFromLastDays()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUsersFromLastDays(7);

			var totalYesterday = result.Single(x => x.Date == Yesterday);
			Assert.AreEqual(3, totalYesterday.Value);

			var totalDayBeforeYesterday = result.Single(x => x.Date == DayBeforeYesterday);
			Assert.AreEqual(1, totalDayBeforeYesterday.Value);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task GetUsersFromLastDaysNegative()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUsersFromLastDays(-1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task GetUsersFromLastDaysZero()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUsersFromLastDays(0);
		}
		#endregion

		#region User activity
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task GetUserActivityNegative()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUsersFromLastDays(-1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public async Task GetUserActivityZero()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUsersFromLastDays(0);
		}

		[TestMethod]
		public async Task GetUserActivity()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUserActivityLastDays(7);

			// Check the number of returned rows
			Assert.AreEqual(8, result.Count);
		}

		[TestMethod]
		public async Task GetUserActivityRowValidation()
		{
			var repo = new DashboardRepository(context);
			var result = await repo.GetUserActivityLastDays(7);

			var totalYesterday = result.Single(x => x.Date == Yesterday);
			Assert.AreEqual(3, totalYesterday.Value);

			var totalDayBeforeYesterday = result.Single(x => x.Date == DayBeforeYesterday);
			Assert.AreEqual(1, totalDayBeforeYesterday.Value);
		}
		#endregion
	}
}
