using JH.RabbitMq.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JH.RabbitMq.Infra.Data.Mappings
{

    public class TemperatureDataStorageMapping : IEntityTypeConfiguration<TemperatureDataStorage>
    {
        public void Configure(EntityTypeBuilder<TemperatureDataStorage> builder)
        {
   
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(u => u.Date)
                  .IsRequired();

            builder.Property(u => u.State)
                 .HasMaxLength(150);

            builder.Property(u => u.Country)
                .HasMaxLength(150);

            builder.ToTable("TemperatureDataStorage");
        }
    }
 
    
}
