using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.DAL.Configuration
{
    public class RoomDbConfiguration : IEntityTypeConfiguration<RoomDb>
    {
        public void Configure(EntityTypeBuilder<RoomDb> builder)
        {
            builder.ToTable("room");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(50);
            builder.Property(x => x.RoomType).HasColumnName("room_type").IsRequired();
            builder.Property(x => x.ApartmentId).HasColumnName("apartment_id").IsRequired();

            builder.HasOne(r => r.Apartment)
                .WithMany(a => a.Rooms)
                .HasForeignKey(a => a.ApartmentId);

            builder.HasMany(r => r.Devices)
                .WithOne(d => d.Room)
                .HasForeignKey(d => d.RoomId);

            builder.HasOne(r => r.RoomType)
            .WithMany()
            .HasForeignKey(r => r.RoomTypeId);
        }
    }
}
