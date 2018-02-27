using BanBrick.Infrastructure.Repositories.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Repositories
{
    public class BanBrickMongoFacade: IBanBrickMongoFacade
    {
        private IMongoDatabase _database;

        public BanBrickMongoFacade(BanBrickMongoContext context)
        {
            _database = context.Database;
        }

    }
}
