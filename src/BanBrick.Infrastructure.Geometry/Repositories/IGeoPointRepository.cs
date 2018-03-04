using BanBrick.Infrastructure.Geometry.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Geometry.Repositories
{
    public interface IGeoPointRepository: IGenericRepository<GeoPoint>
    {
        Task<IAsyncCursor<GeoPoint>> GetByCoordinateAsync(double latitude, double longitude);

        Task<IAsyncCursor<GeoPoint>> GetByDistanceAsync(double latitude, double longitude, double distance);
    }
}
