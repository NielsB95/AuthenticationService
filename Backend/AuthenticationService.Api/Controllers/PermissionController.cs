using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Api.Controllers
{
    [Route("Permissions")]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Permission>>> GetPermission()
        {
            return Ok(await this.permissionRepository.GetAll());
        }
    }
}
