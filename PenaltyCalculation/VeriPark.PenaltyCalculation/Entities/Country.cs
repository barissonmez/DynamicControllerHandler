using System;
using System.Collections.Generic;

namespace VeriPark.PenaltyCalculation.Entities
{
    public class Country
    {
        public Country()
        {
            Holidays = new List<Holiday>();
            WeekendDays = new List<WeekendDay>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CultureCode { get; set; }
        public decimal PenaltyAmount { get; set; }

        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<WeekendDay> WeekendDays { get; set; }
    }
}