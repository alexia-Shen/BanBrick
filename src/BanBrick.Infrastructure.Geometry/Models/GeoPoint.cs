﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry.Models
{
    public class GeoPoint
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public GeoJson2DCoordinates Point { get; set; }

        public string Identifier { get; set; }
    }
}