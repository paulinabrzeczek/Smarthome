using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_smarthome.DAL.Configuration
{
    public class GuestDbConfiguration : IEntityTypeConfiguration<GuestDb>
    {
        public void Configure(EntityTypeBuilder<GuestDb> builder)
        {
            builder.ToTable("guest");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Firstname).HasColumnName("firstname").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Lastname).HasColumnName("lastname").IsRequired().HasMaxLength(50);
            builder.Property(x => x.ApartmentId).HasColumnName("apartment_id").IsRequired(false);

            builder.HasOne(x => x.Apartment)
                .WithMany(x => x.Guest)
                .HasForeignKey(x => x.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
