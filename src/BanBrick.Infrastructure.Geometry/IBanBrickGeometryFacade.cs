using BanBrick.Infrastructure.Geometry.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry
{
    public interface IBanBrickGeometryFacade
    {
        IMongoRepository<GeoPoint> GeoPoints { get; }

        IMongoDatabase Database { get; }
    }
}
