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
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationService.Security.Tests
{
    [TestClass]
    public class AuthenticatorTests
    {
        private AuthenticationServiceContext context;
        private IUserRepository userRepository;
        private IAuthenticationLogRepository authenticationLogRepository;
        private PasswordHashing passwordHashing;
        private TokenGenerator tokenGenerator;
        private IConfiguration configuration;

        private Authenticator authenticator;

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
                Username = "john",
                Lastname = "Joe",
                Password = "+Y0VT7pj7C7vvMUsmBBaaGHoCvrSrO6hUWglzbec7Ag=",
                CreatedAt = new DateTime(2018, 12, 22),
                Role = admin
            });
            context.Add(new User()
            {
                Username = "Jane",
                Lastname = "",
                Password = "pass",
                CreatedAt = new DateTime(2018, 12, 23),
                Role = admin
            });
            context.SaveChanges();

            userRepository = new UserRepository(context);
            authenticationLogRepository = new AuthenticationLogRepository(context);
            passwordHashing = new PasswordHashing();

            var configMock = new Mock<IConfiguration>();
            configMock.Setup(x => x["Secret"]).Returns("2OzslhneIrPaTS/T5MY3ZU4oOjE2hYGsNJJ6fuKEKoP/blm9acKUzR/vEAVstkKwetZJzU3OSf2b5zsllxDwyA==");
            configuration = configMock.Object;
            tokenGenerator = new TokenGenerator(configuration);

            authenticator = new Authenticator(userRepository, authenticationLogRepository, passwordHashing, tokenGenerator);
        }

        [TestMethod]
        public async Task AuthenticationTest()
        {
            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate("john", "pass", ipAddress);

            Assert.AreNotEqual("", result);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UsernameNullTest()
        {
            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate(null, "pass", ipAddress);
        }

        [TestMethod]
        public async Task UnknownUsernameTest()
        {
            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate("Unknown", "pass", ipAddress);

            Assert.AreEqual("", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task NullPasswordTest()
        {
            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate("john", null, ipAddress);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task NullIPAddressTest()
        {
            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate("john", "pass", null);
        }

        [TestMethod]
        public async Task AuthenticationLogTest()
        {
            var beforeCount = (await authenticationLogRepository.GetAll()).Count;

            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate("john", "pass", ipAddress);

            var afterCount = (await authenticationLogRepository.GetAll()).Count;
            Assert.AreEqual(beforeCount + 1, afterCount);
        }

        [TestMethod]
        public async Task AuthenticationLogNotAddedOnFailTest()
        {
            var beforeCount = (await authenticationLogRepository.GetAll()).Count;
            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate("Unknown", "pass", ipAddress);

            var afterCount = (await authenticationLogRepository.GetAll()).Count;

            // On fail, beforeCount should equal afterCount
            Assert.AreEqual(beforeCount, afterCount);
        }

        [TestMethod]
        public async Task AuthenticationLogNotAddedOnWrongPassTest()
        {
            var beforeCount = (await authenticationLogRepository.GetAll()).Count;
            var ipAddress = new IPAddress(0x00000);
            var result = await authenticator.Authenticate("john", "wrongpass", ipAddress);

            var afterCount = (await authenticationLogRepository.GetAll()).Count;

            // On fail, beforeCount should equal afterCount
            Assert.AreEqual(beforeCount, afterCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GenerateTokenNUllUserTest()
        {
            tokenGenerator.GenerateToken(null, null);
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
