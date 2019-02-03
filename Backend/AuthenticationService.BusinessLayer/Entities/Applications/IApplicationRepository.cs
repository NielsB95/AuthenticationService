using System;
using System.Threading.Tasks;

namespace AuthenticationService.BusinessLayer.Entities.Applications
{
	public interface IApplicationRepository : IRepository<Application>
	{
		Task<Application> GetByApplicationCode(Guid applicationCode);
	}
}
