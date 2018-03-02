using BanBrick.Infrastructure.Geometry.Models;
using BanBrick.Infrastructure.Geometry.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry
{
    public interface IBanBrickGeometryFacade
    {
        IGeoPointRepository GeoPoints { get; }

        IMongoDatabase Database { get; }
    }
}
