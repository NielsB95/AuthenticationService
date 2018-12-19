using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.BusinessLayer.Entities.Dashboard;

namespace AuthenticationService.Controllers
{
    [Route("Dashboard")]
    public class DashboardController : ControllerBase
    {
        private IDashboardRepository dashboardRepository;

        public DashboardController(IDashboardRepository dashboardRepository)
        {
            this.dashboardRepository = dashboardRepository;
        }

        [HttpGet("UsersFromLastDays")]
        public async Task<ActionResult<IList<DateValuePair>>> GetUsersFromLastWeeks()
        {
            return Ok(await this.dashboardRepository.GetUsersFromLastDays(14));
        }

        [HttpGet("UserActivityFromLastDays")]
        public async Task<ActionResult<IList<DateValuePair>>> GetActivityFromLastWeeks()
        {
            return Ok(await this.dashboardRepository.GetUserActivityLastDays(14));
        }
    }
}
