using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationServiceContext context) : base(context)
        {
        }
    }
}
