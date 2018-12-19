using System.Collections.Generic;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using System.Linq;

namespace AuthenticationService.DataLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AuthenticationServiceContext context) : base(context)
        { }
    }
}
