using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.DAL.Configuration
{
    public class ApartmentDbConfiguration : IEntityTypeConfiguration<ApartmentDb>
    {
        public void Configure(EntityTypeBuilder<ApartmentDb> builder)
        {
            builder.ToTable("apartment");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50); ;
            builder.Property(x => x.UserId).HasColumnName("user_Id").IsRequired();

            builder.HasOne(x => x.Address)
               .WithOne(x => x.Apartment)
               .HasForeignKey<AddressDb>(x => x.ApartmentId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.Rooms)
                .WithOne(r => r.Apartment)
                .HasForeignKey(r => r.ApartmentId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);

            builder.HasOne(a => a.User)
                .WithMany(u => u.Apartments)
                .HasForeignKey(u => u.UserId);
        }
    }
}
