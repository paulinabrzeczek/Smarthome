using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_smarthome.DAL.Configuration
{
    public class DevicesDbConfiguration : IEntityTypeConfiguration<DevicesDb>
    {
        public void Configure(EntityTypeBuilder<DevicesDb> builder)
        {
            builder.ToTable("devicess");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.SerialNumber).HasColumnName("serial_number").IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();
            builder.Property(x => x.DeviceId).HasColumnName("device_id").IsRequired(false);
            builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired(false);

            builder.HasOne(d => d.Device)
                .WithOne(p => p.Devices)
                .HasForeignKey<DevicesDb>(d => d.DeviceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Devices)
                .HasForeignKey(x => x.UserId)
                .IsRequired(false);
        }
    }
}
