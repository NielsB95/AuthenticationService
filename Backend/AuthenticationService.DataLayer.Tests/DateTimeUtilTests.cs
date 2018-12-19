using System;
using AuthenticationService.DataLayer.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationService.DataLayer.Tests
{
    [TestClass]
    public class DateTimeUtilTests
    {
        [TestMethod]
        public void DateTimeRangeTest()
        {
            var start = DateTime.Today;
            var end = DateTime.Today.AddDays(5);

            var dates = DateTimeUtil.Range(start, end);
            Assert.AreEqual(6, dates.Count);
        }

        [TestMethod]
        public void DateTimeRangeDateTest()
        {
            var start = DateTime.Today;
            var end = DateTime.Today.AddDays(3);

            var dates = DateTimeUtil.Range(start, end);
            Assert.AreEqual(start, dates[0]);
            Assert.AreEqual(start.AddDays(1), dates[1]);
            Assert.AreEqual(start.AddDays(2), dates[2]);
            Assert.AreEqual(end, dates[3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void EndDateBeforeStartDateTest()
        {
            var today = DateTime.Today;
            var yesterday = DateTime.Today.AddDays(-1);

            DateTimeUtil.Range(today, yesterday);
        }
    }
}
