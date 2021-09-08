using Microsoft.EntityFrameworkCore;
using Vehicules.API.Data.Entities;

namespace Vehicules.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<VehiculeType> VehiculeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehiculeType>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
