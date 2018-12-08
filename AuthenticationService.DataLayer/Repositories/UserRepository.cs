using System.Collections.Generic;
using AuthenticationService.BusinessLayer.Entities.Users;

namespace AuthenticationService.DataLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public override IList<User> GetAll()
        {
            return new List<User>()
            {
                new User(){
                    Firstname = "John",
                    Lastname = "Doe"
                }
            };
        }
    }
}
