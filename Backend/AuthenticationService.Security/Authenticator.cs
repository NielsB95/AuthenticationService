using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
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
		private readonly IApplicationUserRepository applicationUserRepository;
		private readonly PasswordHashing passwordHashing;
		private readonly TokenGenerator tokenGenerator;

		public Authenticator(IUserRepository userRepository, IAuthenticationLogRepository authenticationLogRepository, IApplicationUserRepository applicationUserRepository, PasswordHashing passwordHashing, TokenGenerator tokenGenerator)
		{
			this.userRepository = userRepository;
			this.authenticationLogRepository = authenticationLogRepository;
			this.applicationUserRepository = applicationUserRepository;
			this.passwordHashing = passwordHashing;
			this.tokenGenerator = tokenGenerator;
		}

		public async Task<string> Authenticate(string username, string password, string applicationCode, IPAddress ipAddress)
		{
			// Get the user that matches the username.
			var user = await userRepository.GetByUsername(username);

			// There is no one in our database with this username.
			if (user == null)
			{
				await CreateAuthenticationLog(null, false);
				return string.Empty;
			}

			// Check if the password is correct.
			var success = passwordHashing.Compare(user, password);

			var parsedApplicationCode = Guid.Parse(applicationCode);
			if (parsedApplicationCode == Guid.Empty)
				throw new ArgumentException("Failed to format '{0}' as Guid", applicationCode);

			// Check if the user has the rights for this applicaiton.
			var isApplicationAuthorized = await this.applicationUserRepository.IsAuthorized(user.ID, parsedApplicationCode);

			// .. also return an empty string if the password didn't match.
			if (!success || !isApplicationAuthorized)
			{
				await CreateAuthenticationLog(user, false);
				return string.Empty;
			}

			// .. add a new logentiry to the authenticationlog.
			await CreateAuthenticationLog(user);

			var token = tokenGenerator.GenerateToken(user, applicationCode, ipAddress);
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
