using System;
using System.Collections.Generic;
using CongestionCharge.Enums;
using CongestionCharge.Helper;
using CongestionCharge.Models;

namespace CongestionCharge
{
    public class GetRate
    {
        public RateData CurrentRateHours(EntryData entryData)
        {
            var rateData = new RateData
            {
                DayRate = 0,
                EveningRate = 0,
                EveningRateSpanTotal = TimeSpan.Zero,
                DayRateSpanTotal = TimeSpan.Zero
            };

            if(entryData.EnterDate.Date==entryData.LeaveDate.Date)
                RateForSingleDay(entryData, rateData);
            else
                RateForMultipleDays(entryData, rateData);

            return rateData;
        }

        private void RateForMultipleDays(EntryData entryData, RateData rateData)
        {
            var isEntryDate = true;
            var listParkingDateTime = new List<DateTime>();

            for (var dateTime = entryData.EnterDate; dateTime < entryData.LeaveDate; dateTime = dateTime.AddDays(1))
            {
                if (dateTime == entryData.LeaveDate) continue;

                listParkingDateTime.Add(dateTime);
                listParkingDateTime.Add(dateTime.Date + new TimeSpan(18, 59, 0));
            }

            listParkingDateTime.Add(entryData.LeaveDate);

            foreach (var parkingDateTime in listParkingDateTime)
            {
                FillRateData(entryData, rateData, isEntryDate, parkingDateTime);
                isEntryDate = false;
            }
        }

        private void RateForSingleDay(EntryData entryData, RateData rateData)
        {
            var isEntryDate = true;
            var dateTime = new DateTime[2];
            dateTime[0] = entryData.EnterDate;
            dateTime[1] = entryData.LeaveDate;            

            foreach (var parkingDateTime in dateTime)
            {
                FillRateData(entryData, rateData, isEntryDate, parkingDateTime);

                isEntryDate = false;
            }
        }

        private void FillRateData(EntryData entryData, RateData rateData, 
            bool isEntryDate, DateTime parkingDateTime)
        {
            DateTime newParkingTime;

            if (CheckDates.WeekEnd(parkingDateTime) ||
                CheckDates.FreeHours(parkingDateTime)) return;

            if (CheckDates.DayRate(parkingDateTime))
            {
                newParkingTime = CheckDates.ChangeDayTime(parkingDateTime);
                rateData.DayRate = entryData.Vehicle == Vehicles.Motorbike ? 1 : 2;
                if (isEntryDate)                
                    rateData.DayRateSpanTotal = TimeSpan.FromHours(12) - newParkingTime.TimeOfDay;                                    
                else                                    
                    rateData.DayRateSpanTotal += newParkingTime.TimeOfDay - TimeSpan.FromHours(7);                
            }
            else
            {
                newParkingTime = CheckDates.ChangeEveningTime(parkingDateTime);
                rateData.EveningRate = entryData.Vehicle == Vehicles.Motorbike ? 1 : 2.5f;

                if (isEntryDate)
                    rateData.EveningRateSpanTotal += TimeSpan.FromHours(19) - newParkingTime.TimeOfDay;
                else                
                    rateData.EveningRateSpanTotal += newParkingTime.TimeOfDay - TimeSpan.FromHours(12);                
            }                        
        }
    }
}