using JH.RabbitMq.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JH.RabbitMq.Infra.Data.Mappings
{
    public class SomeDataMapping : IEntityTypeConfiguration<SomeData>
    {
        public void Configure(EntityTypeBuilder<SomeData> builder)
        {
            // Override nvarchar(max) with nvarchar(15)
            builder.HasKey(u => u.Id);
            builder.Property(u => u.CreateDate)
                .IsRequired();
            builder.Property(u => u.Content)
                .HasColumnType("varchar(max)");

            // Make the default table name of AspNetUsers to Users
            builder.ToTable("SomeDataStorage");
        }
    }
}
