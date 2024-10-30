using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_smarthome.DAL.Configuration
{
    public class RoomTypeDbConfiguration : IEntityTypeConfiguration<RoomTypeDb>
    {
        public void Configure(EntityTypeBuilder<RoomTypeDb> builder)
        {
            builder.ToTable("room_type");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Code).HasColumnName("code").IsRequired().HasMaxLength(15);
            builder.Property(x => x.Value).HasColumnName("value").IsRequired().HasMaxLength(15);

            builder.HasData(
                new RoomTypeDb { Id = 1, Code = "BATHROOM", Value = "Bathroom" },
                new RoomTypeDb { Id = 2, Code = "BEDROOM", Value = "Bedroom" },
                new RoomTypeDb { Id = 3, Code = "KITCHEN", Value = "Kitchen" },
                new RoomTypeDb { Id = 4, Code = "LIVING_ROOM ", Value = "Living room" },
                new RoomTypeDb { Id = 5, Code = "HALL", Value = "Hall" },
                new RoomTypeDb { Id = 6, Code = "DINING_ROOM", Value = "Dining rooom" }
                );
        }
    }
}