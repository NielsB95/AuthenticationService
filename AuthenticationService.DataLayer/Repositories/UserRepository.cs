using AuthenticationService.BusinessLayer.Entities;
using AuthenticationService.BusinessLayer.Entities.Users;

namespace AuthenticationService.DataLayer.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
	}
}
