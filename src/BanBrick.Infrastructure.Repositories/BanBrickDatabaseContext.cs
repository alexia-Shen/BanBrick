using BanBrick.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BanBrick.Infrastructure.Repositories
{
    public class BanBrickDatabaseContext: DbContext
    {
        public BanBrickDatabaseContext(DbContextOptions<BanBrickDatabaseContext> options):base(options) { }
        
        public virtual DbSet<RestaurantService> DeliveryServices { get; set; }

        public virtual DbSet<Restaurant> Restaurants { get; set; }

        public virtual DbSet<FileSource> FileSources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<RestaurantService>()
                .HasOne(x => x.Restaurant)
                .WithMany(x => x.DeliveryServices)
                .HasForeignKey(x => x.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Restaurant>()
                .HasIndex(x => x.GeoPoint);
        }
    }
}
