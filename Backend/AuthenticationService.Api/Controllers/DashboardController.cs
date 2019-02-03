using AuthenticationService.BusinessLayer.Entities.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Api.Controllers
{
	[Route("Dashboard")]
	[Produces("application/json")]
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

		[HttpGet("FailedAuthenticationActivityLastDays")]
		public async Task<ActionResult<IList<DateValuePair>>> GetFailedAuthenticationActivityLastDays()
		{
			return Ok(await this.dashboardRepository.GetFailedAuthenticationActivityLastDays(14));
		}

		[HttpGet("SuccesfulAuthenticationActivityLastDays")]
		public async Task<ActionResult<IList<DateValuePair>>> GetSuccesfulAuthenticationActivityLastDays()
		{
			return Ok(await this.dashboardRepository.GetSuccesfulAuthenticationActivityLastDays(14));
		}
	}
}
