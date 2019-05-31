using System;
using CongestionCharge.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CongestionChargeTests.Helper
{
    [TestClass()]
    public class CheckDatesTests
    {
        [TestMethod()]
        public void DayRateTest()
        {
            DateTime dateTime = new DateTime(2019,05,20,7,50,0);
            
            Assert.IsTrue(DateChecker.IsDayRate(dateTime));
        }

        [TestMethod()]
        public void FreeHoursTest()
        {
            DateTime dateTime = new DateTime(2019, 05, 20, 6, 50, 0);

            Assert.IsTrue(DateChecker.IsFreeHours(dateTime));
        }

        [TestMethod()]
        public void WeekEndTest()
        {
            DateTime dateTime = new DateTime(2019, 05, 26, 6, 50, 0);

            Assert.IsTrue(DateChecker.IsWeekEnd(dateTime));
        }
    }
}