

using AuthenticationService.BusinessLayer.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthenticationService.Security.Tokens
{
	public class TokenGenerator
	{
		private readonly string secret;
		public TokenGenerator(IConfiguration configuration)
		{
			secret = configuration["Secret"];
		}

		public string GenerateToken(User user, Guid applicationCode, IPAddress ipAddress, int expireMinutes = 20)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (ipAddress == null)
				throw new ArgumentNullException(nameof(ipAddress));

			var key = Convert.ToBase64String(new HMACSHA256().Key);
			var symmetricKey = Convert.FromBase64String(secret);
			var tokenHandler = new JwtSecurityTokenHandler();

			var claims = new[] {
				new Claim("UserID", user.ID.ToString()),
				new Claim("Name", user.Fullname),
				new Claim("UserIP", ipAddress.ToString()),
				new Claim("ApplicationCode", applicationCode.ToString()),
				new Claim("RoleID", user.Role.ID.ToString())
			};

			var now = DateTime.UtcNow;
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = "Authentication.Service",
				IssuedAt = now,
				Subject = new ClaimsIdentity(claims),
				Expires = now.AddMinutes(Convert.ToInt32(expireMinutes)),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
			};

			var securityToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(securityToken);

			return token;
		}
	}
}
