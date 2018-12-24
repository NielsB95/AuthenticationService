using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.Security.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Api.Controllers
{
    [Route("Applications")]
    [Produces("application/json")]
    [IsSuperAdmin]
    public class ApplicationController : ControllerBase
    {
        private IApplicationRepository applicationRepository;

        public ApplicationController(IApplicationRepository applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Application>>> GetApplications()
        {
            return Ok(await applicationRepository.GetAll());
        }
    }
}
