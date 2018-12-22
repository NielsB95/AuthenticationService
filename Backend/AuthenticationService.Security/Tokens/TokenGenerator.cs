using AuthenticationService.BusinessLayer.Entities.Users;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthenticationService.Security.Tokens
{
	public static class TokenGenerator
	{
		public static string GenerateToken(User user, IPAddress ipAddress, int expireMinutes = 20)
		{
			var key = Convert.ToBase64String(new HMACSHA256().Key);
			var symmetricKey = Convert.FromBase64String("");
			var tokenHandler = new JwtSecurityTokenHandler();

			var claims = new[] {
				new Claim("UserId", user.ID.ToString()),
				new Claim("Name", user.Fullname),
				new Claim("UserIp", ipAddress.ToString()),
			};

			var now = DateTime.UtcNow;
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = "authentication.service",
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
