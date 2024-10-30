using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_smarthome.DAL.Configuration
{
    public class HeadDbConfiguration : IEntityTypeConfiguration<HeadDb>
    {
        public void Configure(EntityTypeBuilder<HeadDb> builder)
        {
            builder.ToTable("head");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.IndoorTemp).HasColumnName("indoor_temp").IsRequired();
            builder.Property(x => x.OutdoorTemp).HasColumnName("outdoor_temp").IsRequired();
            builder.Property(x => x.MaxTemp).HasColumnName("max_temp").IsRequired();
            builder.Property(x => x.MinTemp).HasColumnName("min_temp").IsRequired();


            builder.Property(x => x.Name).HasColumnName("name").IsRequired();
            builder.Property(x => x.RoomId).HasColumnName("room_id").IsRequired();
            builder.Property(x => x.Active).HasColumnName("active").IsRequired();
            builder.Property(x => x.Symbol).HasColumnName("symbol").IsRequired();
            builder.Property(x => x.Value).HasColumnName("value").IsRequired();
            builder.Property(x => x.DeviceTypeId).HasColumnName("device_type_id").IsRequired();
            builder.Property(x => x.DevicesId).HasColumnName("devices_id").IsRequired();

        }
    }
}
