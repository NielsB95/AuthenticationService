﻿using AuthenticationService.Api.Models;
using AuthenticationService.Api.Util;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Controllers
{
	[Route("Authenticate")]
	[Produces("application/json")]
	[AllowAnonymous]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticator authenticator;
		private readonly IIPAddressTools ipAddressTools;
		private readonly IUserRepository userRepository;

		public AuthenticationController(IAuthenticator authenticator, IIPAddressTools ipAddressTools, IUserRepository userRepository)
		{
			this.authenticator = authenticator;
			this.ipAddressTools = ipAddressTools;
			this.userRepository = userRepository;
		}

		[HttpPost]
		public virtual async Task<ActionResult<Task>> Authenticate([FromForm]string username, [FromForm] string password, [FromForm] Guid applicationcode)
		{
			// Get the ip where the user requested the token from.
			var ipAddress = this.ipAddressTools.GetIPAddress(this.HttpContext);

			// Try to generate a token.
			var token = await authenticator.Authenticate(username, password, applicationcode, ipAddress);

			// Respond with a Unauthorized when no token is created.
			if (string.IsNullOrEmpty(token))
				return Unauthorized();

			// Compose the AuthenticationModel
			var authenticationModel = new AuthenticationModel()
			{
				User = await userRepository.GetByUsername(username),
				Token = token
			};

			// Return the AuthenticationModel.
			return Ok(authenticationModel);
		}
	}
}
