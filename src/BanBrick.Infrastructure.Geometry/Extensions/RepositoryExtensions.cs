using BanBrick.Infrastructure.Geometry.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BanBrick.Infrastructure.Geometry.Extensions
{
    public static class RepositoryExtensions
    {
        public static Lazy<IMongoRepository<TEntity>> GetLazyRepository<TEntity>(this IMongoDatabase mongoDatabase) where TEntity : class
        {
            var bsonCollection = typeof(TEntity).GetCustomAttribute<BsonCollectionAttribute>();
            var collectionname = bsonCollection != null ? bsonCollection.Name : typeof(TEntity).Name;

            return new Lazy<IMongoRepository<TEntity>>(() => new MongoRepository<TEntity>(mongoDatabase, collectionname));
        }
    }
}
