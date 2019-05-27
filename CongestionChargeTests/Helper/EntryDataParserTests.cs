using CongestionCharge.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CongestionChargeTests.Helper
{
    [TestClass()]
    public class EntryDataParserTests
    {
        [TestMethod()]
        public void FillEntryDataTest()
        {
            var result=EntryDataParser.FillEntryData("Car: 24/04/2008 11:32 - 24/04/2008 14:42");
            Assert.AreEqual("Car",result.Vehicle.ToString());
        }
    }
}