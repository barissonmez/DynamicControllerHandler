using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using VeriPark.PenaltyCalculation.Models;

namespace VeriPark.PenaltyCalculation.Facilities
{
    public static class Facilities
    {
        const int Daylimit = 10;

        public static ModelWrapper Calculate(PenaltyCalculationInModel model)
        {
            var result = new ModelWrapper();

            try
            {
                
                var cultureInfo = new CultureInfo(model.CultureCode);

                var businessDaysCount = CalculateBusinessDays(model);

                var totalLatency = businessDaysCount > Daylimit ? businessDaysCount - Daylimit : 0;

                var totalPenalty = model.Amount * totalLatency;


                var resultModel = new PenaltyCalculationResultOutModel()
                {
                    TotalDays = businessDaysCount.ToString(cultureInfo),
                    TotalPenalty = totalPenalty.ToString("C", cultureInfo)

                };

                result.Result = resultModel;
                
            }
            catch (Exception)
            {

                result.IsSuccess = false;
                result.Message = "An error occured. Please try again.";
                
            }
            return result;
        }

        private static int CalculateBusinessDays(PenaltyCalculationInModel model)
        {
            var cultureInfo = new CultureInfo(model.CultureCode);

            var checkOutDate = Convert.ToDateTime(model.CheckOutDate, cultureInfo);
            var returnDate = Convert.ToDateTime(model.ReturnDate, cultureInfo);

            var totalDays = GetDateRange(checkOutDate, returnDate);

            var daysWithoutWeekends = ExcludeWeekendDays(totalDays, model.WeekendDays);

            var daysWithoutHolidays = ExcludeHolidays(daysWithoutWeekends, model.Holidays);

            return daysWithoutHolidays.Count();
        }



        private static IEnumerable<DateTime> GetDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
                throw new ArgumentException("endDate must be greater than or equal to startDate");

            while (startDate <= endDate)
            {
                yield return startDate;
                startDate = startDate.AddDays(1);
            }
        }

        private static IEnumerable<DateTime> ExcludeWeekendDays(IEnumerable<DateTime> days, ICollection<int> weekendDays)
        {
            var result = new List<DateTime>();

            foreach (var day in days)
            {
                result.AddRange(weekendDays.TakeWhile(weekendDay => (int) day.DayOfWeek != weekendDay).Select(weekendDay => day));
            }

            return result.Distinct();

        }

        private static IEnumerable<DateTime> ExcludeHolidays(IEnumerable<DateTime> days, IEnumerable<DateTime> holidays)
        {
            var result = new List<DateTime>();

            foreach (var day in days)
            {
                result.AddRange(holidays.TakeWhile(holiday => day.Date != holiday.Date).Select(holiday => day));
            }

            return result.Distinct();

        }


    }
}