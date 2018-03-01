using BanBirck.Domain.Models.Geometry;
using BanBrick.Domain.Models.Common;
using System;
using System.Collections.Generic;

namespace BanBrick.Domain.Models.Presentation
{
    public class Restaurant
    {
        public Restaurant() {
            Tags = new List<Tag>();
            DeliveryServices = new List<RestaurantDeliveryService>();
        }

        public string Name { get; set; }

        public GeoPoint Coordinate { get; set; }

        public Address Address { get; set; }

        public Suburb Suburb { get; set; }

        public IList<Tag> Tags { get; set; }

        public IList<RestaurantDeliveryService> DeliveryServices { get; set; }
    }
}
