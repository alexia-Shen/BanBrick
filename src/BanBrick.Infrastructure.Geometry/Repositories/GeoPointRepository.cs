using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BanBrick.Infrastructure.Geometry.Extensions;
using BanBrick.Infrastructure.Geometry.Models;
using MongoDB.Driver;

namespace BanBrick.Infrastructure.Geometry.Repositories
{
    public class GeoPointRepository : GenericRepository<GeoPoint>, IGeoPointRepository
    {
        public GeoPointRepository(IMongoDatabase database) : base(database, typeof(GeoPoint).GetBsonCollectoinName())
        {
        }
    }
}
