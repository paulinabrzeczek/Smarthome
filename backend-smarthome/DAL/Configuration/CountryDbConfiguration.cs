using backend_smarthome.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend_smarthome.DAL.Configuration
{
    public class CountryDbConfiguration : IEntityTypeConfiguration<CountryDb>
    {
        public void Configure(EntityTypeBuilder<CountryDb> builder)
        {
            builder.ToTable("country");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Code).HasColumnName("code").IsRequired().HasMaxLength(20);
            builder.Property(x => x.Value).HasColumnName("value").IsRequired().HasMaxLength(10);

            builder.HasMany(c => c.Address)
                .WithOne(a => a.Country)
                .HasForeignKey(a => a.CountryId);
        }
    }

}
