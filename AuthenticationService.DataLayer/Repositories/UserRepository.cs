using AuthenticationService.BusinessLayer.Entities.Users;
using System.Collections.Generic;

namespace AuthenticationService.DataLayer.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public override IList<User> GetAll()
		{
			return new List<User>()
			{
				new User(){
				Firstname = "Niels", Lastname = "Boerkamp"}

			};
		}
	}
}
