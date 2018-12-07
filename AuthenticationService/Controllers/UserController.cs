using AuthenticationService.BusinessLayer.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AuthenticationService.Controllers
{
	[Route("Users")]
	public class UserController : ControllerBase
	{
		private IUserRepository userRepository;

		public UserController(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		[HttpGet]
		public ActionResult<IList<User>> GetUsers()
		{
			return Ok(userRepository.GetAll());
		}
	}
}
