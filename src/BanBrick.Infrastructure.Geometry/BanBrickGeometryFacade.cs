using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry
{
    public class BanBrickGeometryFacade: IBanBrickGeometryFacade
    {
        private IMongoDatabase _database;

        public BanBrickGeometryFacade(BanBrickGeometryContext context)
        {
            _database = context.Database;
        }

    }
}
