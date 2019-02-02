using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AuthenticationService.BusinessLayer.Tests.Entities
{
    [TestClass]
    public class ApplicationTests
    {
        [TestMethod]
        public void ValidateInvalidApplication()
        {
            var application = new Application();

            var result = EntityValidator.Validate(application);

            Assert.IsTrue(result.Any());

            var messages = result.Select(x => x.ErrorMessage);
            Assert.IsTrue(messages.Contains("The Name field is required."));
        }

        [TestMethod]
        public void ValidateValidApplication()
        {
            var application = new Application()
            {
                Name = "Product service",
                ApplicationCode = new Guid()
            };

            var result = EntityValidator.Validate(application);

            Assert.IsFalse(result.Any());
        }
    }
}
