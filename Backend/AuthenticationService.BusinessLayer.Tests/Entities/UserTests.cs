using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.BusinessLayer.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Security;

namespace AuthenticationService.BusinessLayer.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void ValidateInvalidUser()
        {
            var user = new User()
            {
                Firstname = "John",
                Lastname = "Doe"
            };

            var result = EntityValidator.Validate(user);

            // This user object is not valid. Therefore, we expect some errors.
            Assert.IsTrue(result.Any());

            var messages = result.Select(x => x.ErrorMessage);
            Assert.IsTrue(messages.Contains("The Username field is required."));
            Assert.IsTrue(messages.Contains("The Password field is required."));
        }

        [TestMethod]
        public void ValidateValidUser()
        {
            var user = new User()
            {
                Firstname = "John",
                Lastname = "Doe",
                Username = "john",
                Password = "secret"
            };

            var result = EntityValidator.Validate(user);

            // This user object is valid. Therefore, we expect no errors.
            Assert.IsFalse(result.Any());
        }

    }
}
