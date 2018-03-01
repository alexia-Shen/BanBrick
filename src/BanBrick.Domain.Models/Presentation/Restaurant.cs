using BanBirck.Domain.Models.Geometry;
using System;
using System.Collections.Generic;

namespace BanBrick.Domain.Models.Presentation
{
    public class Restaurant
    {
        public string Name { get; set; }

        public GeoPoint Coordinate { get; set; }

        public Address Address { get; set; }

        public Suburb Suburb { get; set; }

        public List<string> Tags { get; set; }
    }
}
