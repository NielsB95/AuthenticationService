using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.Api.Controllers;
using AuthenticationService.BusinessLayer.Entities.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AuthenticationService.Api.Tests.Controllers
{
    [TestClass]
    public class UserControllerTests : ApiTests
    {
        private IUserRepository userRepository;
        private UserController userController;

        [TestInitialize]
        public void Initialize()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(x => x.GetAll()).ReturnsAsync(GetUsers());
            userRepository = mockRepo.Object;

            userController = new UserController(userRepository);
        }

        [TestMethod]
        public async Task GET_GetUsers()
        {
            var response = await userController.GetUsers();
            var users = GetResult(response);

            Assert.AreEqual(2, users.Count);
        }

        /// <summary>
        /// Creates a test set of users.
        /// </summary>
        /// <returns></returns>
        private IList<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Firstname = "John"
                },
                new User()
                {
                    Firstname = "Jane"
                }
            };
        }
    }
}
