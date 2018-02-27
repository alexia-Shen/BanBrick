using BanBrick.Infrastructure.Repositories.MySql.Models;
using Rissole.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Repositories
{
    public interface IBanBrickMySqlFacade
    {
        void SaveChanges();

        Task SaveChangesAsync();

        IGenericRepository<Restaurant> Restaurants { get; }
    }
}
