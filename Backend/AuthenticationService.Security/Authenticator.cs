using AuthenticationService.BusinessLayer.Entities.Users;
using System.Net;

namespace AuthenticationService.Security
{
	public class Authenticator
	{
		private readonly IUserRepository userRepository;

		public Authenticator(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		public string Authenticate(string username, string password, IPAddress ipAddress)
		{
			var user = userRepository.GetByUsername(username);

			// There is no one in our database with this username.
			if (user == null)
				return string.Empty;





			return string.Empty;
		}
	}
}
