using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Api.Controllers
{
    [Route("AuthenticationLogs")]
    [Produces("application/json")]
    public class AuthenticationLogController : ControllerBase
    {
        private IAuthenticationLogRepository authenticationLogRepository;

        public AuthenticationLogController(IAuthenticationLogRepository authenticationLogRepository)
        {
            this.authenticationLogRepository = authenticationLogRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IList<AuthenticationLog>>> GetLogs()
        {
            return Ok(await this.authenticationLogRepository.GetAll());
        }
    }
}
