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




			return string.Empty;
		}
	}
}
