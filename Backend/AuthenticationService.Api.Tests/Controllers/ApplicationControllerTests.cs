using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.Api.Controllers;
using AuthenticationService.BusinessLayer.Entities.Applications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AuthenticationService.Api.Tests.Controllers
{
    [TestClass]
    public class ApplicationControllerTests : ApiTests
    {
        private IApplicationRepository applicationRepository;
        private ApplicationController applicationController;

        [TestInitialize]
        public async Task Initialize()
        {
            var mockRepo = new Mock<IApplicationRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(GetTestApplications());
            applicationRepository = mockRepo.Object;

            // Check if everything is setup correctly.
            var apps = await applicationRepository.GetAll();
            Assert.AreEqual(2, apps.Count);

            applicationController = new ApplicationController(applicationRepository);
        }

        [TestMethod]
        public async Task GET_GetAllTest()
        {
            var response = await applicationController.GetApplications();
            var applications = GetResult(response);

            Assert.AreEqual(2, applications.Count);
        }

        /// <summary>
        /// A set of applications to test with.
        /// </summary>
        /// <returns>The test applications.</returns>
        private IList<Application> GetTestApplications()
        {
            return new List<Application>()
            {
                new Application()
                {
                    Name = "Test 1"
                },
                new Application()
                {
                    Name = "Test 2"
                }
            };
        }
    }
}
