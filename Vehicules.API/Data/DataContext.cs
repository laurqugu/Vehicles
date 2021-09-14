using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vehicules.API.Data.Entities;

namespace Vehicules.API
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Detail> Details { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<Vehicle> Vehicules { get; set; }
        public DbSet<VehiclePhoto> VehiculePhotos { get; set; }
        public DbSet<VehiculeType> VehiculeTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Procedure>().HasIndex(x => x.Description).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Plaque).IsUnique();
            modelBuilder.Entity<VehiculeType>().HasIndex(x => x.Description).IsUnique();
        }
    }
}
