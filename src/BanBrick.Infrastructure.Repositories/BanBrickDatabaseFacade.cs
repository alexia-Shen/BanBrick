using BanBrick.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using Rissole.EntityFramework;
using Rissole.EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Repositories
{
    public class BanBrickDatabaseFacade: IBanBrickDatabaseFacade
    {
        private BanBrickDatabaseContext _context;

        private Lazy<IGenericRepository<Restaurant>> _restaurantRepository => _context.Restaurants.GetLazyRepository();
        private Lazy<IGenericRepository<DeliveryService>> _deliveryServiceRepository => _context.DeliveryServices.GetLazyRepository();
        
        public BanBrickDatabaseFacade(BanBrickDatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Restaurant> Restaurants => _restaurantRepository.Value;

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
