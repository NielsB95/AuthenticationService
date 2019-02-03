using System;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Repositories
{
	public class ApplicationRepository : Repository<Application>, IApplicationRepository
	{
		public ApplicationRepository(AuthenticationServiceContext context) : base(context)
		{
		}

		public async Task<Application> GetByApplicationCode(Guid applicationCode)
		{
			return await context.Applications
				.Where(x => x.ApplicationCode == applicationCode)
				.ToAsyncEnumerable()
				.FirstOrDefault();
		}
	}
}
