using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Repositories;
using AuthenticationService.Security.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationService.Security.Tests
{
	[TestClass]
	public class AuthenticatorTests
	{
		private AuthenticationServiceContext context;
		private IUserRepository userRepository;
		private IAuthenticationLogger logger;
		private IApplicationUserRepository applicationUserRepository;
		private IAuthenticationLogRepository authenticationLogRepository;
		private IApplicationRepository applicationRepository;
		private PasswordHashing passwordHashing;
		private SymmetricTokenGenerator tokenGenerator;
		private IConfiguration configuration;

		private Authenticator authenticator;

		private Guid applicationCode = Guid.NewGuid();
		private Guid applicationID = Guid.NewGuid();
		private Guid johnID = Guid.NewGuid();
		private Guid janeID = Guid.NewGuid();

		[TestInitialize]
		public void Initialize()
		{
			context = DataLayer.Tests.TestContext.CreateContext();

			var admin = context.Add(new Role()
			{
				ID = Guid.NewGuid(),
				Name = "Admin"
			}).Entity;

			context.Add(new User()
			{
				ID = johnID,
				Username = "john",
				Lastname = "Joe",
				Password = "+Y0VT7pj7C7vvMUsmBBaaGHoCvrSrO6hUWglzbec7Ag=",
				CreatedAt = new DateTime(2018, 12, 22),
				Role = admin
			});
			context.Add(new User()
			{
				ID = janeID,
				Username = "Jane",
				Lastname = "",
				Password = "+Y0VT7pj7C7vvMUsmBBaaGHoCvrSrO6hUWglzbec7Ag=",
				CreatedAt = new DateTime(2018, 12, 23),
				Role = admin
			});

			context.Add(new Application() { ID = applicationID, Name = "Authentication service", ApplicationCode = applicationCode });
			context.Add(new ApplicationUser() { ApplicationID = applicationID, UserID = johnID });

			context.SaveChanges();

			userRepository = new UserRepository(context);

			applicationUserRepository = new ApplicationUserRepository(context);
			passwordHashing = new PasswordHashing();
			authenticationLogRepository = new AuthenticationLogRepository(context);
			applicationRepository = new ApplicationRepository(context);

			logger = new AuthenticationLogger(authenticationLogRepository, applicationRepository);

			var configMock = new Mock<IConfiguration>();
			configMock.Setup(x => x["Secret"]).Returns("2OzslhneIrPaTS/T5MY3ZU4oOjE2hYGsNJJ6fuKEKoP/blm9acKUzR/vEAVstkKwetZJzU3OSf2b5zsllxDwyA==");
			configuration = configMock.Object;
			tokenGenerator = new SymmetricTokenGenerator(configuration);

			authenticator = new Authenticator(userRepository, applicationUserRepository, logger, passwordHashing, tokenGenerator);
		}

		[TestMethod]
		public async Task AuthenticationTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("john", "pass", applicationCode, ipAddress);

			Assert.AreNotEqual("", result);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public async Task ApplicationCodeTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("jane", "pass", applicationCode, ipAddress);

			Assert.AreEqual("", result);
			Assert.IsNotNull(result);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public async Task UsernameNullTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate(null, "pass", applicationCode, ipAddress);
		}

		[TestMethod]
		public async Task UnknownUsernameTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("Unknown", "pass", applicationCode, ipAddress);

			Assert.AreEqual("", result);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public async Task NullPasswordTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("john", null, applicationCode, ipAddress);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public async Task NullIPAddressTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("john", "pass", applicationCode, null);
		}

		[TestMethod]
		public async Task AuthenticationLogTest()
		{
			var beforeCount = (await authenticationLogRepository.GetAll()).Count;

			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("john", "pass", applicationCode, ipAddress);

			var afterCount = (await authenticationLogRepository.GetAll()).Count;
			Assert.AreEqual(beforeCount + 1, afterCount);
		}

		[TestMethod]
		public async Task AuthenticationLogNotAddedOnFailTest()
		{
			var beforeCount = (await authenticationLogRepository.GetAll()).Count;
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("Unknown", "pass", applicationCode, ipAddress);

			var afterCount = (await authenticationLogRepository.GetAll()).Count;

			Assert.AreEqual(beforeCount + 1, afterCount);
		}

		[TestMethod]
		public async Task AuthenticationLogNotAddedOnWrongPassTest()
		{
			var beforeCount = (await authenticationLogRepository.GetAll()).Count;
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("john", "wrongpass", applicationCode, ipAddress);

			var afterCount = (await authenticationLogRepository.GetAll()).Count;

			Assert.AreEqual(beforeCount + 1, afterCount);
		}

		[TestMethod]
		public async Task AuthenticationLogStatusOnWrongPassTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("john", "wrongpass", applicationCode, ipAddress);

			var latestLog = (await authenticationLogRepository.GetAll())
							.OrderBy(x => x.CreatedAt)
							.First();

			Assert.IsFalse(latestLog.Successful);
		}

		[TestMethod]
		public async Task AuthenticationLogStatusOnUnknownUserTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("Unknown", "wrongpass", applicationCode, ipAddress);

			var latestLog = (await authenticationLogRepository.GetAll())
							.OrderBy(x => x.CreatedAt)
							.First();

			Assert.IsFalse(latestLog.Successful);
		}

		[TestMethod]
		public async Task AuthenticationLogStatusOnSuccessTest()
		{
			var ipAddress = new IPAddress(0x00000);
			var result = await authenticator.Authenticate("john", "pass", applicationCode, ipAddress);

			var latestLog = (await authenticationLogRepository.GetAll())
							.OrderBy(x => x.CreatedAt)
							.First();

			Assert.IsTrue(latestLog.Successful);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void GenerateTokenNUllUserTest()
		{
			tokenGenerator.GenerateToken(null, Guid.Empty, null);
		}

		[TestCleanup]
		public async Task CleanUp()
		{
			context.RemoveRange(context.Users);
			context.RemoveRange(context.AuthenticationLogs);
			await context.SaveChangesAsync();
		}
	}
}
