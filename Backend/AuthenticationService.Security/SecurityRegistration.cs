using AuthenticationService.Security.Tokens;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationService.Security
{
	public static class SecurityRegistration
	{
		public static IServiceCollection AddSecurity(this IServiceCollection services)
		{
			services.AddScoped<Authenticator>();
			services.AddScoped<PasswordHashing>();
			services.AddScoped<TokenGenerator>();

			return services;
		}
	}
}
