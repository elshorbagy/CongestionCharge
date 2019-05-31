using System;
using CongestionCharge.Enums;

namespace CongestionCharge.Models
{
    public class EntryData
    {
        public Vehicle Vehicle { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}
