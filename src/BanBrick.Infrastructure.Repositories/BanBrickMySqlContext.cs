using BanBrick.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BanBrick.Infrastructure.Repositories
{
    public class BanBrickMySqlContext: DbContext
    {
        public BanBrickMySqlContext(DbContextOptions<BanBrickMySqlContext> options):base(options) { }
        
        public virtual DbSet<DeliveryService> DeliveryServices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {

        }
    }
}
