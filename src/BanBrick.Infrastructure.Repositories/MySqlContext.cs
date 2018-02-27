using BanBrick.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BanBrick.Infrastructure.Repositories
{
    public class MySqlContext: DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options):base(options) { }
        
        public virtual DbSet<DeliveryService> DeliveryServices { get; set; }

        public virtual DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {

        }
    }
}
