using System;

namespace CongestionCharge.Models
{
    public class RateData
    {
        public TimeSpan DayRateSpanTotal{ get; set; }
        public TimeSpan EveningRateSpanTotal { get; set; }
        public float DayRate { get; set; }
        public float EveningRate { get; set; }
    }
}
