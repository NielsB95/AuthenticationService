using AuthenticationService.BusinessLayer.Entities.Permissions;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(AuthenticationServiceContext context) : base(context)
        {
        }
    }
}
