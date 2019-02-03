using AuthenticationService.BusinessLayer.Entities.Users;
using AuthenticationService.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.DataLayer.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(AuthenticationServiceContext context) : base(context)
		{ }

		public async Task<User> GetByUsername(string username)
		{
			if (string.IsNullOrEmpty(username))
				throw new ArgumentNullException(nameof(username));

			return await (context.Users
				.Include(x => x.Role)
				.Where(x => x.Username.ToLower() == username.ToLower())
				.ToAsyncEnumerable())
				.FirstOrDefault();
		}
	}
}
