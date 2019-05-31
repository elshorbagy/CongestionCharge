using CongestionCharge;
using CongestionCharge.Helper;
using CongestionCharge.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CongestionChargeTests
{
    [TestClass()]
    public class GetRateTests
    {
        [TestMethod()]
        public void CurrentRateHoursTest()
        {
            var getRate = new RateCalculation();
            var rateData = getRate.CurrentRateHours
                (
                    EntryDataParser.FillEntryData("Car: 24/04/2008 11:32 - 24/04/2008 14:42")
                );            
            Assert.IsInstanceOfType(rateData,typeof(RateData));
        }
    }
}