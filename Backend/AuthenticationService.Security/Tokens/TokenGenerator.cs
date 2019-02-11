

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
		private readonly string publicKey;
		private readonly string privateKey;

		public TokenGenerator(IConfiguration configuration)
		{
			publicKey = configuration["Keys:Public"];
			privateKey = configuration["Secret:Private"];
		}

		public string GenerateToken(User user, Guid applicationCode, IPAddress ipAddress, int expireMinutes = 20)
		{
			if (user == null)
				throw new ArgumentNullException(nameof(user));

			if (ipAddress == null)
				throw new ArgumentNullException(nameof(ipAddress));

			//var key = Convert.ToBase64String(new HMACSHA256().Key);
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
				NotBefore = now,
				SigningCredentials = new SigningCredentials(new AsymmetricSecurityKey(symmetricKey), SecurityAlgorithms.RsaSha512)
			};

			var securityToken = tokenHandler.CreateToken(tokenDescriptor);
			var token = tokenHandler.WriteToken(securityToken);

			return token;
		}
	}
}
