using System;

namespace CongestionCharge.Helper
{
    public static class DateChecker
    {
        public static DateTime ChangeDayTime(DateTime date)
        {
            if (date.Hour >= 7) return date;
            var newTime = new TimeSpan(7, 0, 0);
            return date.Date + newTime;
        }

        public static DateTime ChangeEveningTime(DateTime date)
        {
            if (date.Hour <= 19) return date;
            var newTime = new TimeSpan(19, 0, 0);
            return date.Date + newTime;
        }

        public static bool IsDayRate(DateTime date) =>
                    date.Hour >= 7 && date.Hour < 12;
        
        public static bool IsFreeHours(DateTime date)=>
             date.Hour >= 19 || date.Hour < 7;

        public static bool IsWeekEnd(DateTime date) =>
            date.DayOfWeek == DayOfWeek.Sunday ||
            date.DayOfWeek == DayOfWeek.Saturday;
    }
}
