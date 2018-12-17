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

        [HttpGet]
        public async Task<ActionResult<IList<DateValuePair>>> GetUsersFromLastWeek()
        {
            return Ok(await this.dashboardRepository.GetUsersFromLastDays(14));
        }
    }
}
