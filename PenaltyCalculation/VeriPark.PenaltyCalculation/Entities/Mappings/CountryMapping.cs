using System.Data.Entity.ModelConfiguration;

namespace VeriPark.PenaltyCalculation.Entities.Mappings
{
    public class CountryMapping : EntityTypeConfiguration<Country>
    {
        public CountryMapping()
        {
            ToTable("Countries");

            // Primary Key
            HasKey(c => c.Id);

            // Properties
            Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(255);
            Property(c => c.CultureCode).HasColumnName("CultureCode").IsRequired().HasMaxLength(10);
            Property(c => c.PenaltyAmount).HasColumnName("PenaltyAmount").IsRequired().HasColumnType("decimal");
        
            // Relations

        }
    }
}