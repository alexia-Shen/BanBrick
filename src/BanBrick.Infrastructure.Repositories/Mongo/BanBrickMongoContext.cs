using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Mongo
{
    public class BanBrickMongoContext
    {
        private MongoConnection _connection;
        private IMongoDatabase _database;

        public BanBrickMongoContext(MongoConnection mongoConnection) {
            _connection = mongoConnection;
            _database = new MongoClient(_connection.ConnectionString).GetDatabase(_connection.Database);
        }

        public IMongoDatabase Database => _database;
    }
}
