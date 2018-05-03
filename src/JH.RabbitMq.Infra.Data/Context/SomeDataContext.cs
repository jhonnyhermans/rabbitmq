using JH.RabbitMq.Domain;
using JH.RabbitMq.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace JH.RabbitMq.Infra.Data.Context
{
    public class SomeDataContext : DbContext
    {
        public DbSet<SomeData> SomeData {get; set;}
        public DbSet<TemperatureDataStorage> TemperatureDataStorage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SomeDataMapping());
            modelBuilder.ApplyConfiguration(new TemperatureDataStorageMapping());
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

         
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        }

   
    }
}
