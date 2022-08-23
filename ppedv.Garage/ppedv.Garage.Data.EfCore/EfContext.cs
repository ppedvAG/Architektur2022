using Microsoft.EntityFrameworkCore;
using ppedv.Garage.Model;

namespace ppedv.Garage.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Car> Cars => Set<Car>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<Location> Locations => Set<Location>();

        private readonly string _conString;

        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=Garage_DEV;Trusted_Connection=true")
        {
            _conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_conString).UseLazyLoadingProxies();
        }
    }
}