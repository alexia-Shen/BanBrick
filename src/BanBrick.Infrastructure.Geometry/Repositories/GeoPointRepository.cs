using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BanBrick.Infrastructure.Geometry.Extensions;
using BanBrick.Infrastructure.Geometry.Models;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace BanBrick.Infrastructure.Geometry.Repositories
{
    public class GeoPointRepository : GenericRepository<GeoPoint>, IGeoPointRepository
    {
        public GeoPointRepository(IMongoDatabase database) : base(database, typeof(GeoPoint).GetBsonCollectoinName())
        {
        }

        public async Task<GeoPoint> GetByCoordinateAsync(double latitude, double longitude)
        {
            var query = Builders<GeoPoint>.Filter.NearSphere(x => x.Point, longitude, latitude);
            return await (await Collection.FindAsync(query)).FirstOrDefaultAsync();
        }

        public async Task<IList<GeoPoint>> GetByDistanceAsync(double latitude, double longitude, double distance)
        {
            var query = Builders<GeoPoint>.Filter.NearSphere(x => x.Point, longitude, latitude, distance);
            return await (await Collection.FindAsync(query)).ToListAsync();
        }
    }
}
