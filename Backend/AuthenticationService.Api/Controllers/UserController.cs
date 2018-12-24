using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.Security.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Controllers
{
    [Route("Users")]
    [Produces("application/json")]
    [IsSuperAdmin]
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
