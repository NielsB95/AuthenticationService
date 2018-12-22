using AuthenticationService.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Controllers
{
	[Route("Authenticate")]
	public class AuthenticationController : ControllerBase
	{
		private readonly Authenticator authenticator;

		public AuthenticationController(Authenticator authenticator)
		{
			this.authenticator = authenticator;
		}

		[HttpPost]
		public async Task<ActionResult<Task>> Authenticate(string username, string password)
		{
			// Get the ip where the user requested the token from.
			var ipAddress = this.HttpContext.Connection.RemoteIpAddress;

			// Try to generate a token.
			var token = await authenticator.Authenticate(username, password, ipAddress);

			// Respond with a Unauthorized when no token is created.
			if (string.IsNullOrEmpty(token))
				return Unauthorized();

			// Return the token.
			return Ok(token);
		}
	}
}
