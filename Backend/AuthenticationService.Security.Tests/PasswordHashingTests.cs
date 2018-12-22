using AuthenticationService.BusinessLayer.Entities.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AuthenticationService.Security.Tests
{
	[TestClass]
	public class PasswordHashingTests
	{
		private readonly PasswordHashing hasher = new PasswordHashing();

		[TestMethod]
		public void HashUserTest()
		{
			var user = new User()
			{
				Firstname = "John",
				CreatedAt = new DateTime(2018, 12, 22),
				Password = "pass"
			};

			var hashedUser = hasher.Hash(user);

			// The password shouldn't equal the previous password.
			Assert.AreNotEqual("pass", user.Password);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void HashNullUserTest()
		{
			hasher.Hash(null);
		}

		[TestMethod]
		public void SaltGeneratorTest()
		{
			var user = new User()
			{
				Firstname = "John",
				CreatedAt = new DateTime(2018, 12, 22),
				Password = "pass"
			};

			var result = hasher.SaltGenerator(user);
			var expectedResult = new byte[] { 104, 17, 143, 116, 42, 245, 92, 7, 160, 200, 5, 184, 245, 176, 135, 108 };

			// It should atleast be not null.
			Assert.IsNotNull(result);

			// Every byte should match
			for (var i = 0; i < expectedResult.Length; i++)
				Assert.AreEqual(expectedResult[i], result[i]);
		}

		[TestMethod]
		public void HashStringTest()
		{
			var salt = new byte[] { 104, 17, 143, 116, 42, 245, 92, 7, 160, 200, 5, 184, 245, 176, 135, 108 };
			var password = "pass";

			var hashedPassword = hasher.Hash(salt, password);

			Assert.AreNotEqual(password, hashedPassword);
			Assert.AreEqual("+Y0VT7pj7C7vvMUsmBBaaGHoCvrSrO6hUWglzbec7Ag=", hashedPassword);
		}

		[TestMethod]
		public void HashPasswordTest()
		{
			var user = new User()
			{
				Firstname = "John",
				CreatedAt = new DateTime(2018, 12, 22),
				Password = "pass"
			};

			Assert.AreEqual("pass", user.Password);

			user = hasher.Hash(user);

			Assert.AreEqual("+Y0VT7pj7C7vvMUsmBBaaGHoCvrSrO6hUWglzbec7Ag=", user.Password);
		}

		[TestMethod]
		public void CompareTest()
		{
			var user = new User()
			{
				Firstname = "John",
				CreatedAt = new DateTime(2018, 12, 22),
				Password = "+Y0VT7pj7C7vvMUsmBBaaGHoCvrSrO6hUWglzbec7Ag="
			};

			Assert.IsTrue(hasher.Compare(user, "pass"));
			Assert.IsFalse(hasher.Compare(user, "Pass"));
		}
	}
}
