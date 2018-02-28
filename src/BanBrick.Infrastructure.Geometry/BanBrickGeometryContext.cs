using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry
{
    public class BanBrickGeometryContext
    {
        private IMongoDatabase _database;

        public BanBrickGeometryContext(MongoOptions options) {
            _database = new MongoClient(options.MongoClientSettings).GetDatabase(options.Database);
        }

        public IMongoDatabase Database => _database;
    }
}
