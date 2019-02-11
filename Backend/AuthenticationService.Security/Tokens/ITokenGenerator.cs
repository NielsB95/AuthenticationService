using System;
using System.Net;
using AuthenticationService.BusinessLayer.Entities.Users;

namespace AuthenticationService.Security.Tokens
{
	public interface ITokenGenerator
	{
		string GenerateToken(User user, Guid applicationCode, IPAddress ipAddress, int expireMinutes = 20);
	}
}
