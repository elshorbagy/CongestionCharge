using System;
using System.Globalization;
using CongestionCharge.Enums;
using CongestionCharge.Models;

namespace CongestionCharge.Helper
{
    public static class EntryDataParser
    {
        public static EntryData FillEntryData(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new ArgumentNullException("data");

            if (!data.Contains(":"))
                throw new Exception("No Vehicle");

            var entryData =new EntryData();
            var rawData = data.Split(' ');
            
            entryData.Vehicle =(Vehicles) Enum.Parse(typeof(Vehicles), rawData[0].Replace(":","").Trim());

            if (!DateTime.TryParseExact(rawData[1] + " " + rawData[2], "dd/MM/yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var enterDate))
            {
                throw new Exception("No Valid Entry Date");
            }

            entryData.EnterDate = enterDate;

            if (!DateTime.TryParseExact(rawData[4] + " " + rawData[5], "dd/MM/yyyy HH:mm",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out var leaveDate))
            {
                throw new Exception("No Valid Leave Date");
            }

            entryData.LeaveDate = leaveDate;

            return entryData;
        }
    }
}
