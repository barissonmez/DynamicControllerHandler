using System.Data.Entity.ModelConfiguration;

namespace VeriPark.PenaltyCalculation.Entities.Mappings
{
    public class HolidayMapping: EntityTypeConfiguration<Holiday>
    {
        public HolidayMapping()
        {
            ToTable("Holidays");

            // Primary Key
            HasKey(c => c.Id);

            // Properties
            Property(c => c.HolidayDate).HasColumnName("HolidayDate").IsRequired().HasColumnType("datetime");

            // Relations
            HasOptional(o => o.Country).WithMany(o => o.Holidays).Map(m => m.MapKey("CountryId")).WillCascadeOnDelete(true);
        }
    }
}