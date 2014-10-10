using System;

namespace VeriPark.PenaltyCalculation.Entities
{
    public class WeekendDay
    {
        public Guid Id { get; set; }
        public int DayOfWeek { get; set; }
        public virtual Country Country { get; set; }
    }
}