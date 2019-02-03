using System;
using AuthenticationService.Security.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationService.Security
{
	public static class SecurityRegistration
	{
		public static IServiceCollection AddSecurity(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IAuthenticator, Authenticator>();
			services.AddScoped<IAuthenticationLogger, AuthenticationLogger>();
			services.AddScoped<PasswordHashing>();
			services.AddScoped<TokenGenerator>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateLifetime = true,
						ValidateAudience = false,
						ValidIssuer = "Authentication.Service",
						IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(configuration["Secret"]))
					};
				});

			return services;
		}

		public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
		{
			app.UseAuthentication();
			return app;
		}
	}
}
