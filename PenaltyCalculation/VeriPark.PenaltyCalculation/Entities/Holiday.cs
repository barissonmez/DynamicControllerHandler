using System;

namespace VeriPark.PenaltyCalculation.Entities
{
    public class Holiday
    {
        public Guid Id { get; set; }
        public DateTime HolidayDate { get; set; }
        public virtual Country Country { get; set; }
        
    }
}