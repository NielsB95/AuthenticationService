using System;
using System.Collections.Generic;
using System.Linq;

namespace AuthenticationService.DataLayer.Util
{
    public static class DateTimeUtil
    {
        public static IList<DateTime> Range(DateTime start, DateTime end)
        {
            if (end < start)
                throw new ArgumentException(string.Format("Argument '{0}' can't be lower than '{1}'", nameof(end), nameof(start)));

            // '+ 1' Since we want it to be inclusive
            return Enumerable.Range(0, end.Subtract(start).Days + 1)
                  .Select(offset => start.AddDays(offset))
                  .ToList();
        }

    }
}
