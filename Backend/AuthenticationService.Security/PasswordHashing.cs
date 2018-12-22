using AuthenticationService.BusinessLayer.Entities.Users;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;

namespace AuthenticationService.Security
{
	public class PasswordHashing
	{
		public bool Compare(User user, string presentedPassword)
		{
			var salt = SaltGenerator(user);
			var presetnedPasswordHashed = Hash(salt, presentedPassword);

			return user.Password == presetnedPasswordHashed;
		}

		public User Hash(User user)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			var salt = SaltGenerator(user);
			user.Password = Hash(salt, user.Password);

			return user;
		}

		internal string Hash(byte[] salt, string password)
		{
			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: password,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA512,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));

			return hashed;
		}

		internal byte[] SaltGenerator(User user)
		{
			// Convert Int64 timestamp to Int32 by taking 
			// its HashCode. We're not really interested in the actual value,
			// therefore the hash suffices.
			var seed = user.CreatedAt.GetHashCode();

			// Do some random stuff with the salt to make it more
			// difficult to guess the password.
			seed = seed * 5;
			seed = seed - 150;

			var random = new Random(seed);

			var salt = new byte[128 / 8];
			random.NextBytes(salt);

			return salt;
		}
	}
}
