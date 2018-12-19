using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationService.DataLayer.Util
{
    public static class DateTimeUtil
    {
        public static IList<DateTime> Range(DateTime start, DateTime end)
        {
            return Enumerable.Range(0, end.Subtract(start).Days)
                  .Select(offset => start.AddDays(offset))
                  .ToList();
        }

    }
}
