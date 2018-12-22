using AuthenticationService.Api.Util;
using AuthenticationService.Security;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Controllers
{
    [Route("Authenticate")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticator authenticator;
        private readonly IIPAddressTools ipAddressTools;

        public AuthenticationController(IAuthenticator authenticator, IIPAddressTools ipAddressTools)
        {
            this.authenticator = authenticator;
            this.ipAddressTools = ipAddressTools;
        }

        [HttpPost]
        public virtual async Task<ActionResult<Task>> Authenticate(string username, string password)
        {
            // Get the ip where the user requested the token from.
            var ipAddress = this.ipAddressTools.GetIPAddress(this.HttpContext);

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
