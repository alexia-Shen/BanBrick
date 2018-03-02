using BanBrick.Infrastructure.Geometry.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Geometry.Repositories
{
    public interface IGeoPointRepository: IGenericRepository<GeoPoint>
    {
        Task<GeoPoint> GetByCoordinateAsync(double latitude, double longitude);

        Task<IList<GeoPoint>> GetByDistanceAsync(double latitude, double longitude, double distance);
    }
}
