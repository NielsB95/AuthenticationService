﻿using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.Security.Tokens;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AuthenticationService.Security
{
	public interface IAuthenticator
	{
		Task<string> Authenticate(string username, string password, string applicationcode, IPAddress ipAddress);
	}

	public class Authenticator : IAuthenticator
	{
		private readonly IUserRepository userRepository;
		private readonly IAuthenticationLogRepository authenticationLogRepository;
		private readonly PasswordHashing passwordHashing;
		private readonly TokenGenerator tokenGenerator;


		public Authenticator(IUserRepository userRepository, IAuthenticationLogRepository authenticationLogRepository, PasswordHashing passwordHashing, TokenGenerator tokenGenerator)
		{
			this.userRepository = userRepository;
			this.authenticationLogRepository = authenticationLogRepository;
			this.passwordHashing = passwordHashing;
			this.tokenGenerator = tokenGenerator;
		}

		public async Task<string> Authenticate(string username, string password, string applicationcode, IPAddress ipAddress)
		{
			// Get the user that matches the username.
			var user = await userRepository.GetByUsername(username);

			// There is no one in our database with this username.
			if (user == null)
			{
				await CreateAuthenticationLog(null, false);
				return string.Empty;
			}

			var success = passwordHashing.Compare(user, password);

			// .. also return an empty string if the password didn't match.
			if (!success)
			{
				await CreateAuthenticationLog(user, false);
				return string.Empty;
			}

			// .. add a new logentiry to the authenticationlog.
			await CreateAuthenticationLog(user);

			var token = tokenGenerator.GenerateToken(user, ipAddress);
			return token;
		}

		private async Task CreateAuthenticationLog(User user, bool succesful = true)
		{
			await authenticationLogRepository.Add(new AuthenticationLog()
			{
				CreatedAt = DateTime.Now,
				User = user,
				Successful = succesful
			});
		}
	}
}
