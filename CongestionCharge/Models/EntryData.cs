using System;
using CongestionCharge.Enums;

namespace CongestionCharge.Models
{
    public class EntryData
    {
        public Vehicles Vehicle { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}
