using BanBrick.Infrastructure.Geometry.Models;
using BanBrick.Infrastructure.Geometry.Extensions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry
{
    public class BanBrickGeometryFacade: IBanBrickGeometryFacade
    {
        private IMongoDatabase _database;
        private Lazy<IMongoRepository<GeoPoint>> _geoPointRepository;

        public BanBrickGeometryFacade(BanBrickGeometryContext context)
        {
            _database = context.Database;

            _geoPointRepository = _database.GetLazyRepository<GeoPoint>("geoPoint");
        }

        public IMongoRepository<GeoPoint> GeoPoints => _geoPointRepository.Value;

        public IMongoDatabase Database => _database;
    }
}
