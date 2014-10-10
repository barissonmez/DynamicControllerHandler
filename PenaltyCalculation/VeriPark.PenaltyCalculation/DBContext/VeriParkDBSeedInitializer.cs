using System;
using System.Collections.Generic;
using System.Data.Entity;
using VeriPark.PenaltyCalculation.Entities;

namespace VeriPark.PenaltyCalculation.DBContext
{
    public class VeriParkDBSeedInitializer : DropCreateDatabaseIfModelChanges<VeriParkDBContext>
    {
        protected override void Seed(VeriParkDBContext context)
        {
            var countries = new List<Country>
                                    {
                                        new Country() { Id= Guid.NewGuid(),
                                                        Name = "Turkey", 
                                                        CultureCode = "tr-TR",
                                                        PenaltyAmount = 5m,
                                                        Holidays = new List<Holiday>()
                                                        {
                                                            new Holiday()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                HolidayDate = new DateTime(2014, 7, 25)
                                                            },
                                                            new Holiday()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                HolidayDate = new DateTime(2014, 7, 26)
                                                            },
                                                            new Holiday()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                HolidayDate = new DateTime(2014, 7, 27)
                                                            },
                                                            new Holiday()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                HolidayDate = new DateTime(2014, 7, 28)
                                                            }
                                                        },
                                                        WeekendDays = new List<WeekendDay>()
                                                        {
                                                            new WeekendDay(){Id = Guid.NewGuid(), DayOfWeek = (int)DayOfWeek.Saturday},
                                                            new WeekendDay(){Id = Guid.NewGuid(), DayOfWeek = (int)DayOfWeek.Sunday},
                                                        }
                                                    },
                                        new Country() { Id= Guid.NewGuid(),
                                                        Name = "Germany", 
                                                        CultureCode = "de-DE",
                                                        PenaltyAmount = 3.62m,
                                                        Holidays = new List<Holiday>()
                                                        {
                                                            new Holiday()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                HolidayDate = new DateTime(2014, 6, 25)
                                                            },
                                                            new Holiday()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                HolidayDate = new DateTime(2014, 7, 27)
                                                            },
                                                            new Holiday()
                                                            {
                                                                Id = Guid.NewGuid(),
                                                                HolidayDate = new DateTime(2014, 8, 28)
                                                            }
                                                        },
                                                        WeekendDays = new List<WeekendDay>()
                                                        {
                                                            new WeekendDay(){Id = Guid.NewGuid(), DayOfWeek = (int)DayOfWeek.Saturday},
                                                            new WeekendDay(){Id = Guid.NewGuid(), DayOfWeek = (int)DayOfWeek.Sunday},
                                                        }
                                                    }
                                    };

            // add data into context and save to db
            countries.ForEach(c=> context.Countries.Add(c));
            context.SaveChanges();

        }
    }
}