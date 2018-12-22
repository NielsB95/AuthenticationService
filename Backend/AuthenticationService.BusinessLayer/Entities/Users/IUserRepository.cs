using System.Threading.Tasks;

namespace AuthenticationService.BusinessLayer.Entities.Users
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetByUsername(string username);
	}
}
