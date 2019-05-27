using System;
using CongestionCharge.Helper;

namespace CongestionCharge
{
    public class CalculateCharges:ICalculateCharges
    {
        public string Charge(string entryData)
        {
            var getRate = new GetRate();
            var rateData = getRate.CurrentRateHours(EntryDataParser.FillEntryData(entryData));
            var dayBill = CalculateBill(rateData.DayRateSpanTotal.TotalMinutes, rateData.DayRate);
            var eveningBill = CalculateBill(rateData.EveningRateSpanTotal.TotalMinutes, rateData.EveningRate);
            var totalBill= CalculateBillTotal(dayBill , eveningBill);

            return "Charge for " + rateData.DayRateSpanTotal.Hours + "h " +
                   rateData.DayRateSpanTotal.Minutes + "m (AM Rate):£" +
                   dayBill + Environment.NewLine +
                   "Charge for " + rateData.EveningRateSpanTotal.Hours + "h " +
                   rateData.EveningRateSpanTotal.Minutes + "m (AM Rate):£" +
                   eveningBill + Environment.NewLine +
                   "Total Charge:£" + totalBill;            
        }

        private double CalculateBill(double minutes,float rate) =>                           
             Math.Round(minutes * (rate / 60),1);

        private double CalculateBillTotal(double dayBill, double eveningBill)=>
            dayBill + eveningBill;
        
    }
}
