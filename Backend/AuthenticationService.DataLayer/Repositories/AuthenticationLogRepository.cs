using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.AuthenticationLogs;
using AuthenticationService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationService.DataLayer.Repositories
{
	public class AuthenticationLogRepository : Repository<AuthenticationLog>, IAuthenticationLogRepository
	{
		public AuthenticationLogRepository(AuthenticationServiceContext context) : base(context)
		{
		}

		public override async Task<IList<AuthenticationLog>> GetAll()
		{
			return await context.AuthenticationLogs
				.Include(x => x.User)
				.Include(x => x.Application)
				.OrderByDescending(x => x.CreatedAt)
				.ToListAsync();
		}
	}
}
