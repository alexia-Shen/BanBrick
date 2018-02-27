using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Mongo.Models
{
    public class Restaurant
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string Name { get; set; }

        public GeoJson2DCoordinates Location { get; set; }

        public Guid Identifier { get; set; }
    }
}
