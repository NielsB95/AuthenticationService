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

			var queryResult = await context.AuthenticationLogs
				.Where(x => x.CreatedAt >= start)
				.GroupBy(x => x.CreatedAt.Date)
				.Select(x => new DateValuePair()
				{
					Value = x.Count(),
					Date = x.Key
				})
				.ToAsyncEnumerable()
				.ToList();

			// Add the missing days (only needed when value is 0)
			foreach (var day in dates)
				if (!queryResult.Select(x => x.Date).Contains(day))
					queryResult.Add(new DateValuePair() { Date = day, Value = 0 });

			// Order the results.
			return queryResult
				.OrderBy(x => x.Date)
				.ToList();
		}

		public async Task<IList<DateValuePair>> GetSuccesfulAuthenticationActivityLastDays(int days)
		{
			if (days <= 0)
				throw new ArgumentException("Days cannot be negative", nameof(days));

			var start = DateTime.Today.AddDays(-days);
			var end = DateTime.Today;
			var dates = DateTimeUtil.Range(start, end);

			var queryResult = await context.AuthenticationLogs
				.Where(x => x.CreatedAt >= start)
				.Where(x => x.Successful)
				.GroupBy(x => x.CreatedAt.Date)
				.Select(x => new DateValuePair()
				{
					Value = x.Count(),
					Date = x.Key
				})
				.ToAsyncEnumerable()
				.ToList();

			// Add the missing days (only needed when value is 0)
			foreach (var day in dates)
				if (!queryResult.Select(x => x.Date).Contains(day))
					queryResult.Add(new DateValuePair() { Date = day, Value = 0 });

			// Order the results.
			return queryResult
				.OrderBy(x => x.Date)
				.ToList();
		}

		public async Task<IList<DateValuePair>> GetFailedAuthenticationActivityLastDays(int days)
		{
			if (days <= 0)
				throw new ArgumentException("Days cannot be negative", nameof(days));

			var start = DateTime.Today.AddDays(-days);
			var end = DateTime.Today;
			var dates = DateTimeUtil.Range(start, end);

			var queryResult = await context.AuthenticationLogs
				.Where(x => x.CreatedAt >= start)
				.Where(x => !x.Successful)
				.GroupBy(x => x.CreatedAt.Date)
				.Select(x => new DateValuePair()
				{
					Value = x.Count(),
					Date = x.Key
				})
				.ToAsyncEnumerable()
				.ToList();

			// Add the missing days (only needed when value is 0)
			foreach (var day in dates)
				if (!queryResult.Select(x => x.Date).Contains(day))
					queryResult.Add(new DateValuePair() { Date = day, Value = 0 });

			// Order the results.
			return queryResult
				.OrderBy(x => x.Date)
				.ToList();
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
