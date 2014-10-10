using System;
using System.Collections.Generic;

namespace VeriPark.PenaltyCalculation.Models
{
    public class PenaltyCalculationInModel
    {
        public PenaltyCalculationInModel()
        {
            Holidays = new List<DateTime>();
        }

        public Guid CountryId { get; set; }
        public string CultureCode { get; set; }
        public decimal Amount { get; set; }
        public string CheckOutDate { get; set; }
        public string ReturnDate { get; set; }
        public ICollection<int> WeekendDays { get; set; }
        public ICollection<DateTime> Holidays { get; set; }
    }
}