using AuthenticationService.BusinessLayer.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
	[Route("Users")]
	[Produces("application/json")]
	public class UserController : ControllerBase
	{
		private IUserRepository userRepository;

		public UserController(IUserRepository userRepository)
		{
			this.userRepository = userRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IList<User>>> GetUsers()
		{
			return Ok(await userRepository.GetAll());
		}
	}
}
