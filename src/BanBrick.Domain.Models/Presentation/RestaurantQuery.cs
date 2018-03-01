using BanBirck.Domain.Models.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Domain.Models.Presentation
{
    public class RestaurantQuery
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Range { get; set; }
        public string OrderBy { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
