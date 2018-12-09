using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Roles;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Route("Roles")]
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