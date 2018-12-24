using AuthenticationService.BusinessLayer.Entities.Permissions;
using AuthenticationService.Security.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Controllers
{
    [Route("Permissions")]
    [Produces("application/json")]
    [IsSuperAdmin]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Permission>>> GetPermissions()
        {
            return Ok(await this.permissionRepository.GetAll());
        }
    }
}
