using System;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationService.DataLayer.Tests
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
            context.Add(new User() { Firstname = "Jane", CreatedAt = DayBeforeYesterday });
            context.Add(new User() { Firstname = "John", CreatedAt = Yesterday });
            context.Add(new User() { Firstname = "Joe", CreatedAt = Yesterday });
            context.SaveChanges();
        }

        [TestCleanup]
        public void CleanUp()
        {
            context.RemoveRange(context.Users);
            context.SaveChanges();
        }

        [TestMethod]
        public async Task CheckDaysGetUsersFromDays()
        {
            var repo = new DashboardRepository(context);
            var result = await repo.GetUsersFromLastDays(7);

            Assert.AreEqual(7, result.Count);
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
    }
}
