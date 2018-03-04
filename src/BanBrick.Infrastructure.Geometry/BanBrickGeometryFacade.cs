using BanBrick.Infrastructure.Geometry.Models;
using BanBrick.Infrastructure.Geometry.Extensions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using BanBrick.Infrastructure.Geometry.Repositories;

namespace BanBrick.Infrastructure.Geometry
{
    public class BanBrickGeometryFacade: IBanBrickGeometryFacade
    {
        private IMongoDatabase _database;
        private Lazy<IGeoPointRepository> _geoPointRepository => new Lazy<IGeoPointRepository>(() => new GeoPointRepository(_database));

        public BanBrickGeometryFacade(BanBrickGeometryContext context)
        {
            _database = context.Database;
        }

        public IGeoPointRepository GeoPoints => _geoPointRepository.Value;

        public IMongoDatabase Database => _database;

        IGeoPointRepository IBanBrickGeometryFacade.GeoPoints => throw new NotImplementedException();
    }
}
