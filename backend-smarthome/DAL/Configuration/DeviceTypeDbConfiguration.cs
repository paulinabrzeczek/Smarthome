using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.DAL.Configuration
{
    public class DeviceTypeDbConfiguration : IEntityTypeConfiguration<DeviceTypeDb>
    {
        public void Configure(EntityTypeBuilder<DeviceTypeDb> builder)
        {
            builder.ToTable("device_type");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Code).HasColumnName("code").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Value).HasColumnName("value").IsRequired().HasMaxLength(20);

            builder.HasOne(d => d.Device)
                .WithOne(x => x.DeviceType)
                .HasForeignKey<DeviceDb>(a => a.DeviceTypeId);
        }

    }
}
