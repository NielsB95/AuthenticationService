using System;
using System.Net;
using System.Threading.Tasks;
using AuthenticationService.Api.Controllers;
using AuthenticationService.Api.Models;
using AuthenticationService.Api.Util;
using AuthenticationService.BusinessLayer.Entities.Users;
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
		private IUserRepository userRepository;
		private AuthenticationController controller;
		private string applicationCode = new Guid().ToString();

		[TestInitialize]
		public void Initialize()
		{

			var ipAddress = IPAddress.Parse("127.0.0.1");
			var mockAuthenticator = new Mock<IAuthenticator>();
			mockAuthenticator.Setup(x => x.Authenticate("John", "pass", applicationCode, ipAddress)).ReturnsAsync("VALID_TOKEN");
			mockAuthenticator.Setup(x => x.Authenticate("Joe", "pass", applicationCode, ipAddress)).ReturnsAsync("");
			authenticator = mockAuthenticator.Object;

			var mockIPAddressTools = new Mock<IIPAddressTools>();
			mockIPAddressTools.Setup(x => x.GetIPAddress(It.IsAny<HttpContext>())).Returns(ipAddress);
			ipAddressTools = mockIPAddressTools.Object;

			var mockUserRepository = new Mock<IUserRepository>();
			mockUserRepository.Setup(x => x.GetByUsername(It.IsAny<string>())).ReturnsAsync(new User() { Firstname = "John" });
			userRepository = mockUserRepository.Object;

			controller = new AuthenticationController(authenticator, ipAddressTools, userRepository);
		}

		[TestMethod]
		public async Task POST_AuthenticateSuccesfullTest()
		{
			var response = await controller.Authenticate("John", "pass", applicationCode);
			var responseResult = response.Result as OkObjectResult;
			var model = responseResult.Value as AuthenticationModel;

			Assert.AreEqual(200, responseResult.StatusCode);
			Assert.AreEqual("VALID_TOKEN", model.Token);
			Assert.AreEqual("John", model.User.Firstname);
		}

		[TestMethod]
		public async Task POST_AuthenticateUnsuccesfullTest()
		{
			var response = await controller.Authenticate("Joe", "pass", applicationCode);
			var responseResult = response.Result as UnauthorizedResult;

			Assert.AreEqual(401, responseResult.StatusCode);
		}
	}
}