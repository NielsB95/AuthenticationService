using System;
using AuthenticationService.BusinessLayer.Entities;

namespace AuthenticationService.DataLayer.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        public Application Add(Application entity)
        {
            return entity;
        }

        public bool Delete(Application entity)
        {
            return true;
        }

        public Application Update(Application entity)
        {
            return entity;
        }
    }
}
