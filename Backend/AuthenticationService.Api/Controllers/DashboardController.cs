using AuthenticationService.BusinessLayer.Entities.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Controllers
{
	[Route("Dashboard")]
	public class DashboardController : ControllerBase
	{
		private readonly IDashboardRepository dashboardRepository;

		public DashboardController(IDashboardRepository dashboardRepository)
		{
			this.dashboardRepository = dashboardRepository;
		}

		[HttpGet("UsersFromLastDays")]
		public async Task<ActionResult<IList<DateValuePair>>> GetUsersFromLastDays()
		{
			return Ok(await this.dashboardRepository.GetUsersFromLastDays(14));
		}

		[HttpGet("UserActivityFromLastDays")]
		public async Task<ActionResult<IList<DateValuePair>>> GetActivityFromLastDays()
		{
			return Ok(await this.dashboardRepository.GetUserActivityLastDays(14));
		}
	}
}
