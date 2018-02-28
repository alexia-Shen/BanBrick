using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry.Extensions
{
    public static class RepositoryExtensions
    {
        public static Lazy<IMongoRepository<TEntity>> GetLazyRepository<TEntity>(this IMongoDatabase mongoDatabase, string collectionName) where TEntity : class
        {
            return new Lazy<IMongoRepository<TEntity>>(() => new MongoRepository<TEntity>(mongoDatabase, collectionName));
        }
    }
}
