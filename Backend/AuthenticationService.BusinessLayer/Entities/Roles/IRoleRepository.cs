using System.Threading.Tasks;

namespace AuthenticationService.BusinessLayer.Entities.Roles
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetSuperAdmin();
    }
}
