using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.Api.Controllers;
using AuthenticationService.BusinessLayer.Entities.Dashboard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AuthenticationService.Api.Tests.Controllers
{
    [TestClass]
    public class DashboardControllerTests : ApiTests
    {
        private IDashboardRepository dashboardRepository;
        private DashboardController dashboardController;

        [TestInitialize]
        public void Initialize()
        {
            var mockRepo = new Mock<IDashboardRepository>();
            mockRepo.Setup(x => x.GetUserActivityLastDays(It.IsAny<int>())).ReturnsAsync(GetUserActivity());
            mockRepo.Setup(x => x.GetUsersFromLastDays(It.IsAny<int>())).ReturnsAsync(GetTotalUsers());
            mockRepo.Setup(x => x.GetSuccesfulAuthenticationActivityLastDays(It.IsAny<int>())).ReturnsAsync(GetSuccesful());
            mockRepo.Setup(x => x.GetFailedAuthenticationActivityLastDays(It.IsAny<int>())).ReturnsAsync(GetFailed());
            dashboardRepository = mockRepo.Object;

            dashboardController = new DashboardController(dashboardRepository);
        }

        [TestMethod]
        public async Task GET_GetUsersFromLastWeeksTest()
        {
            var response = await dashboardController.GetUsersFromLastDays();
            var data = GetResult(response);

            Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public async Task GET_GetActicityFromLastWeeksTest()
        {
            var response = await dashboardController.GetActivityFromLastDays();
            var data = GetResult(response);

            Assert.AreEqual(4, data.Count);
        }

        [TestMethod]
        public async Task GET_GetSuccesfulAuthenticationActivityLastDays()
        {
            var response = await dashboardController.GetSuccesfulAuthenticationActivityLastDays();
            var data = GetResult(response);

            Assert.AreEqual(5, data.Count);
        }

        [TestMethod]
        public async Task GET_GetFailedAuthenticationActivityLastDays()
        {
            var response = await dashboardController.GetFailedAuthenticationActivityLastDays();
            var data = GetResult(response);

            Assert.AreEqual(3, data.Count);
        }

        /// <summary>
        /// Test data for user activity
        /// </summary>
        /// <returns></returns>
        private IList<DateValuePair> GetUserActivity()
        {
            return new List<DateValuePair>()
            {
                new DateValuePair() {Date =DateTime.Today, Value = 1},
                new DateValuePair() {Date =DateTime.Today.AddDays(1), Value = 40},
                new DateValuePair() {Date =DateTime.Today.AddDays(2), Value = 20},
                new DateValuePair() {Date =DateTime.Today.AddDays(3), Value = 30},
            };
        }

        /// <summary>
        /// Test data for the total users
        /// </summary>
        /// <returns></returns>
        private IList<DateValuePair> GetTotalUsers()
        {
            return new List<DateValuePair>()
            {
                new DateValuePair() {Date =DateTime.Today, Value = 1},
                new DateValuePair() {Date =DateTime.Today.AddDays(1), Value = 40},
                new DateValuePair() {Date =DateTime.Today.AddDays(2), Value = 20},
                new DateValuePair() {Date =DateTime.Today.AddDays(3), Value = 30},
            };
        }

        private IList<DateValuePair> GetSuccesful()
        {
            return new List<DateValuePair>()
            {
                new DateValuePair() {Date =DateTime.Today, Value = 1},
                new DateValuePair() {Date =DateTime.Today.AddDays(1), Value = 40},
                new DateValuePair() {Date =DateTime.Today.AddDays(2), Value = 20},
                new DateValuePair() {Date =DateTime.Today.AddDays(3), Value = 30},
                new DateValuePair() {Date =DateTime.Today.AddDays(4), Value = 60},
            };
        }

        private IList<DateValuePair> GetFailed()
        {
            return new List<DateValuePair>()
            {
                new DateValuePair() {Date =DateTime.Today, Value = 1},
                new DateValuePair() {Date =DateTime.Today.AddDays(1), Value = 40},
                new DateValuePair() {Date =DateTime.Today.AddDays(3), Value = 30},
            };
        }
    }
}
