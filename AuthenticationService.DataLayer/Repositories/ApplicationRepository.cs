using AuthenticationService.BusinessLayer.Entities.Applications;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Repositories
{
    public class ApplicationRepository : Repository<Application>, IApplicationRepository
    {
        public ApplicationRepository(AuthenticationServiceContext context) : base(context)
        {
        }
    }
}
