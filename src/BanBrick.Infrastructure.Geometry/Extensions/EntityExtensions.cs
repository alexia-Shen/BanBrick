using BanBrick.Infrastructure.Geometry.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BanBrick.Infrastructure.Geometry.Extensions
{
    public static class EntityExtensions
    {
        public static string GetBsonCollectoinName(this Type type)
        {
            var bsonCollection = type.GetCustomAttribute<BsonCollectionAttribute>();
            var collectionname = bsonCollection != null ? bsonCollection.Name : type.Name;

            return collectionname;
        }
    }
}
