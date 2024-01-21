using Microsoft.EntityFrameworkCore;
using RailwayManagement.Entities;
using Pomelo.EntityFrameworkCore.MySql;

namespace RailwayManagement
{
    internal class RailwayContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure your database connection here
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));
            optionsBuilder.UseMySql("server=localhost;database=railwayproject;user=root;password=password", serverVersion);
        }
    }
}
