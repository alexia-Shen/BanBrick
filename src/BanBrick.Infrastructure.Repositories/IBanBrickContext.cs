using BanBrick.Infrastructure.Repositories.Models;
using Rissole.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Repositories
{
    public interface IBanBrickContext
    {
        void SaveChanges();

        Task SaveChangesAsync();

        IGenericRepository<Restaurant> Restaurants { get; }
    }
}
