using System;
using System.Threading.Tasks;

namespace AuthenticationService.BusinessLayer.Entities.Applications
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser>
	{
		Task<bool> IsAuthorized(Guid userid, Guid applicationCode);
	}
}
