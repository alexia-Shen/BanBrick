﻿using BanBrick.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BanBrick.Infrastructure.Repositories
{
    public class BanBrickDatabaseContext: DbContext
    {
        public BanBrickDatabaseContext(DbContextOptions<BanBrickDatabaseContext> options):base(options) { }
        
        public virtual DbSet<DeliveryService> DeliveryServices { get; set; }

        public virtual DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<DeliveryService>()
                .HasOne(x => x.Restaurant)
                .WithMany(x => x.DeliveryServices)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}