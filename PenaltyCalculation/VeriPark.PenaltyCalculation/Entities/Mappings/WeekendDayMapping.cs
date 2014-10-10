using System.Data.Entity.ModelConfiguration;

namespace VeriPark.PenaltyCalculation.Entities.Mappings
{
    public class WeekendDayMapping : EntityTypeConfiguration<WeekendDay>
    {
        public WeekendDayMapping()
        {
            ToTable("WeekendDays");

            // Primary Key
            HasKey(c => c.Id);

            // Properties
            Property(c => c.DayOfWeek).HasColumnName("DayOfWeek").IsRequired().HasColumnType("int");

            // Relations
            HasOptional(o => o.Country).WithMany(o => o.WeekendDays).Map(m => m.MapKey("CountryId")).WillCascadeOnDelete(true);
        }
    }
}