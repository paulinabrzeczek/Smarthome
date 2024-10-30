using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_smarthome.DAL.Configuration
{
    public class AddressDbConfiguration : IEntityTypeConfiguration<AddressDb>
    {
        public void Configure(EntityTypeBuilder<AddressDb> builder)
        {
            builder.ToTable("address");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Country).HasColumnName("country").IsRequired();
            builder.Property(x => x.City).HasColumnName("city").IsRequired();
            builder.Property(x => x.Postcode).HasColumnName("postcode").IsRequired();
            builder.Property(x => x.Street).HasColumnName("street").IsRequired();
            builder.Property(x => x.BuildingNumber).HasColumnName("building_number").IsRequired();
            builder.Property(x => x.FlatNumber).HasColumnName("flat_number").IsRequired();
            builder.Property(x => x.ApartmentId).HasColumnName("apartment_id").IsRequired();
            builder.Property(x => x.CountryCode).HasColumnName("country_code").IsRequired().HasMaxLength(10);

            builder.HasOne(a => a.Apartment)
                .WithOne(x => x.Address)
                .HasForeignKey<AddressDb>(a => a.ApartmentId);

            builder.HasOne(a => a.Country)
               .WithMany(c => c.Address)
               .HasForeignKey(a => a.CountryId);

        }
    }
}
