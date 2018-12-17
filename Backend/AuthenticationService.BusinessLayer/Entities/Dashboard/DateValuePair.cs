using System;
using System.Diagnostics;

namespace AuthenticationService.BusinessLayer.Entities.Dashboard
{
    [DebuggerDisplay("{Date} - {Value}")]
    public class DateValuePair
    {
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
    }
}
