using System;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Repositories
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		public ApplicationUserRepository(AuthenticationServiceContext context) : base(context)
		{
		}

		public async Task<bool> IsAuthorized(Guid userid, Guid applicationCode)
		{
			var application = context.Applications
				.Where(x => x.ApplicationCode == applicationCode)
				.FirstOrDefault();

			if (application == null)
			{
#if DEBUG
				throw new ArgumentException(string.Format("There is no application with application code {0}", applicationCode));
#else
				return false;
#endif
			}

			return await context.ApplicationUsers
				.Where(x => x.UserID == userid)
				.Where(x => x.ApplicationID == application.ID)
				.ToAsyncEnumerable()
				.Any();
		}
	}
}
