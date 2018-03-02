using BanBrick.Infrastructure.Geometry.Attributes;
using BanBrick.Infrastructure.Geometry.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BanBrick.Infrastructure.Geometry.Extensions
{
    public static class RepositoryExtensions
    {
        public static Lazy<IGenericRepository<TEntity>> GetLazyRepository<TEntity>(this IMongoDatabase mongoDatabase) where TEntity : class
        {
            return new Lazy<IGenericRepository<TEntity>>(() => new GenericRepository<TEntity>(mongoDatabase, typeof(TEntity).GetBsonCollectoinName()));
        }
    }
}
