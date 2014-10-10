using System;
using System.Collections.Generic;

namespace VeriPark.PenaltyCalculation.Models
{
    public class PenaltyCalculationOutModel
    {
        public PenaltyCalculationOutModel()
        {
            Countries = new List<CountryModel>();
        }

        public ICollection<CountryModel> Countries { get; set; }

        public class CountryModel
        {
            public Guid CountryId { get; set; }
            public string Name { get; set; }
        }
    }
}