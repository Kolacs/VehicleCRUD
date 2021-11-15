using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataLayer
{
    public class VehicleContext : DbContext
    {

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public VehicleContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VehicleDatabase;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(new[]
            {
                new Vehicle { RegistrationId = "AAA111", Description = "Big white volvo car", MakeId = 1, TypeId = 1 },
                new Vehicle { RegistrationId = "BBB222", Description = "Green fast Suzuki bike", MakeId = 4, TypeId = 2 },
                new Vehicle { RegistrationId = "CCC333", Description = "This is a Saab car", MakeId = 2, TypeId = 1 },
                new Vehicle { RegistrationId = "DDD444", Description = "Exclusive Honda bike", MakeId = 3, TypeId = 2 }
            });
            modelBuilder.Entity<VehicleMake>().HasData(new[]
{
                new VehicleMake { MakeId = 1, Description = "Volvo" },
                new VehicleMake { MakeId = 2, Description = "Saab" },
                new VehicleMake { MakeId = 3, Description = "Honda" },
                new VehicleMake { MakeId = 4, Description = "Suzuki" }
            });

            modelBuilder.Entity<VehicleType>().HasData(new[]
            {
                new VehicleType { TypeId = 1, Description = "Car" },
                new VehicleType {TypeId = 2, Description = "Bike" }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
