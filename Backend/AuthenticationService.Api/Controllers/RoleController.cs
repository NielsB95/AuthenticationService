using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.Security.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Api.Controllers
{
    [Route("Roles")]
    [Produces("application/json")]
    [IsSuperAdmin]
    public class RoleController : ControllerBase
    {
        private IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Role>>> GetRoles()
        {
            return Ok(await roleRepository.GetAll());
        }
    }
}