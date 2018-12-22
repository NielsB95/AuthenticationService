using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Repositories
{
	public class AuthenticationLogRepository : Repository<AuthenticationLog>, IAuthenticationLogRepository
	{
		public AuthenticationLogRepository(AuthenticationServiceContext context) : base(context)
		{
		}
	}
}
