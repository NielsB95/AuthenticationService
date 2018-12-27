using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationService.BusinessLayer.Entities.Dashboard;
using AuthenticationService.DataLayer.Context;
using AuthenticationService.DataLayer.Util;

namespace AuthenticationService.DataLayer.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private AuthenticationServiceContext context;

        public DashboardRepository(AuthenticationServiceContext context)
        {
            this.context = context;
        }

        public async Task<IList<DateValuePair>> GetUserActivityLastDays(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days cannot be negative", nameof(days));

            var start = DateTime.Today.AddDays(-days);
            var end = DateTime.Today;
            var dates = DateTimeUtil.Range(start, end);

            var query = (from date in dates
                         let activity = (from log in context.AuthenticationLogs
                                         where log.CreatedAt.Date == date
                                         select log).Count()
                         select new DateValuePair()
                         {
                             Date = date,
                             Value = activity
                         }).ToAsyncEnumerable();

            return await query.ToList();
        }

        public async Task<IList<DateValuePair>> GetSuccesfulAuthenticationActivityLastDays(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days cannot be negative", nameof(days));

            var start = DateTime.Today.AddDays(-days);
            var end = DateTime.Today;
            var dates = DateTimeUtil.Range(start, end);

            var query = (from date in dates
                         let activity = (from log in context.AuthenticationLogs
                                         where log.CreatedAt.Date == date
                                         && log.Successful
                                         select log).Count()
                         select new DateValuePair()
                         {
                             Date = date,
                             Value = activity
                         }).ToAsyncEnumerable();

            return await query.ToList();
        }

        public async Task<IList<DateValuePair>> GetFailedAuthenticationActivityLastDays(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days cannot be negative", nameof(days));

            var start = DateTime.Today.AddDays(-days);
            var end = DateTime.Today;
            var dates = DateTimeUtil.Range(start, end);

            var query = (from date in dates
                         let activity = (from log in context.AuthenticationLogs
                                         where log.CreatedAt.Date == date
                                         && !log.Successful
                                         select log).Count()
                         select new DateValuePair()
                         {
                             Date = date,
                             Value = activity
                         }).ToAsyncEnumerable();

            return await query.ToList();
        }

        public async Task<IList<DateValuePair>> GetUsersFromLastDays(int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days cannot be negative", nameof(days));

            var start = DateTime.Today.AddDays(-days);
            var end = DateTime.Today;
            var dates = DateTimeUtil.Range(start, end);

            var query = (from date in dates
                         let sumUsers = (from user in context.Users
                                         where user.CreatedAt.Date <= date
                                         select user).Count()

                         select new DateValuePair()
                         {
                             Date = date,
                             Value = sumUsers,

                         }).ToAsyncEnumerable();

            return await query.ToList();
        }

    }
}
