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
        private Lazy<IGenericRepository<RestaurantService>> _restaurantServiceRepository => _context.DeliveryServices.GetLazyRepository();
        private Lazy<IGenericRepository<FileSource>> _fileSourceRepository => _context.FileSources.GetLazyRepository();

        public BanBrickDatabaseFacade(BanBrickDatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Restaurant> Restaurants => _restaurantRepository.Value;
        public IGenericRepository<RestaurantService> RestaurantServices => _restaurantServiceRepository.Value;
        public IGenericRepository<FileSource> FileSources => _fileSourceRepository.Value;

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
