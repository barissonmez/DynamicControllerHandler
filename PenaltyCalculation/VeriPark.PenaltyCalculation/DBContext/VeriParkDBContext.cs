using System.Data.Entity;
using VeriPark.PenaltyCalculation.Entities;
using VeriPark.PenaltyCalculation.Entities.Mappings;

namespace VeriPark.PenaltyCalculation.DBContext
{
    public class VeriParkDBContext : DbContext
    {
        private static readonly object LockedObject = new object();
        private bool _modelReady;

        public VeriParkDBContext()
            : base("VeriParkDBContext")
        {
            
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;

            Database.SetInitializer(new VeriParkDBSeedInitializer());
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<WeekendDay> WeekendDays { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();

            if (_modelReady) return;
            lock (LockedObject)
            {
                if (_modelReady) return;

                _modelReady = true;


                ConfigureMappings(modelBuilder);

                base.OnModelCreating(modelBuilder);
            }

        }

        private void ConfigureMappings(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryMapping());
            modelBuilder.Configurations.Add(new HolidayMapping());
            modelBuilder.Configurations.Add(new WeekendDayMapping());
        }
    }
}