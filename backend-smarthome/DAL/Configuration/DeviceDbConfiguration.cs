using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace backend_smarthome.DAL.Configuration
{
    public class DeviceDbConfiguration : IEntityTypeConfiguration<DeviceDb>
    {
        public void Configure(EntityTypeBuilder<DeviceDb> builder)
        {
            builder.ToTable("device");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Active).HasColumnName("active").IsRequired();
            builder.Property(x => x.Symbol).HasColumnName("symbol").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Property(x => x.RoomId).HasColumnName("room_id").IsRequired();
            builder.Property(x => x.DeviceTypeId).HasColumnName("device_type_id").IsRequired();

            builder.HasOne(d => d.Room)
                .WithMany(r => r.Devices)
                .HasForeignKey(r => r.RoomId);

            builder.HasOne(d => d.DeviceType)
               .WithOne(x => x.Device)
               .HasForeignKey<DeviceDb>(a => a.DeviceTypeId);

            builder.HasIndex(d => d.DeviceTypeId).IsUnique(false);

        }
    }   
}

