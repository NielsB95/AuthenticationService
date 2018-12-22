using System.Net;
using System.Threading.Tasks;
using AuthenticationService.Api.Controllers;
using AuthenticationService.Api.Util;
using AuthenticationService.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AuthenticationService.Api.Tests.Controllers
{
    [TestClass]
    public class AuthenticationControllerTests : ApiTests
    {
        private IAuthenticator authenticator;
        private IIPAddressTools ipAddressTools;
        private AuthenticationController controller;

        [TestInitialize]
        public void Initialize()
        {
            var ipAddress = IPAddress.Parse("127.0.0.1");
            var mockAuthenticator = new Mock<IAuthenticator>();
            mockAuthenticator.Setup(x => x.Authenticate("John", "pass", ipAddress)).ReturnsAsync("VALID_TOKEN");
            mockAuthenticator.Setup(x => x.Authenticate("Joe", "pass", ipAddress)).ReturnsAsync("");
            authenticator = mockAuthenticator.Object;

            var mockIPAddressTools = new Mock<IIPAddressTools>();
            mockIPAddressTools.Setup(x => x.GetIPAddress(It.IsAny<HttpContext>())).Returns(ipAddress);
            ipAddressTools = mockIPAddressTools.Object;

            controller = new AuthenticationController(authenticator, ipAddressTools);
        }

        [TestMethod]
        public async Task POST_AuthenticateSuccesfullTest()
        {
            var response = await controller.Authenticate("John", "pass");
            var responseResult = response.Result as OkObjectResult;
            var token = responseResult.Value as string;

            Assert.AreEqual(200, responseResult.StatusCode);
            Assert.AreEqual("VALID_TOKEN", token);
        }

        [TestMethod]
        public async Task POST_AuthenticateUnsuccesfullTest()
        {
            var response = await controller.Authenticate("Joe", "pass");
            var responseResult = response.Result as UnauthorizedResult;

            Assert.AreEqual(401, responseResult.StatusCode);
        }
    }
}
