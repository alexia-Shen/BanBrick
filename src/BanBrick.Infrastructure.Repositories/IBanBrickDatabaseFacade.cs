using BanBrick.Infrastructure.Repositories.Models;
using Rissole.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Repositories
{
    public interface IBanBrickDatabaseFacade
    {
        void SaveChanges();

        Task SaveChangesAsync();

        IGenericRepository<Restaurant> Restaurants { get; }
    }
}
