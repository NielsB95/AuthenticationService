using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Dashboard;
using AuthenticationService.DataLayer.Context;

namespace AuthenticationService.DataLayer.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private AuthenticationServiceContext context;

        public DashboardRepository(AuthenticationServiceContext context)
        {
            this.context = context;
        }

        public async Task<IList<DateValuePair>> AccountsFromLastWeek()
        {
            var start = DateTime.Today.AddDays(-7);
            var end = DateTime.Today;
            var dates = Enumerable.Range(0, 1 + end.Subtract(start).Days)
                  .Select(offset => start.AddDays(offset))
                  .ToArray();

            return await (from date in dates
                          let sumUsers = (from user in context.Users
                                          where user.CreatedAt < date
                                          select user).Count()

                          select new DateValuePair()
                          {
                              Date = date,
                              Value = sumUsers,

                          }).ToAsyncEnumerable().ToList();
        }

    }
}
