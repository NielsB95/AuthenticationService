using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Roles;
using AuthenticationService.DataLayer.Context;
using System.Linq;

namespace AuthenticationService.DataLayer.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(AuthenticationServiceContext context) : base(context)
        { }

        /// <summary>
        /// This function gets the super admin from the database. An exception
        /// could be thrown if it finds more than one 'Super Admin'.
        /// </summary>
        /// <returns>The super admin.</returns>
        public Role GetSuperAdmin()
        {
            return (from role in context.Roles
                    where role.Name == "Super admin"
                    select role)
                    .Single();

        }
    }
}
