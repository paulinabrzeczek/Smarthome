using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace backend_smarthome.DAL.Configuration
{
    public class UserDbConfiguration : IEntityTypeConfiguration<UserDb>
    {
        public void Configure(EntityTypeBuilder<UserDb> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.Username).HasColumnName("username").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnName("email").IsRequired(false).HasMaxLength(75);

            builder.HasMany(u => u.Apartments)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(u => u.Devices)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);
        }
    }
}
