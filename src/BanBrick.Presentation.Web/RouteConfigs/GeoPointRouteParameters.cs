using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanBrick.Presentation.Web.RouteConfigs
{
    public static class GeoPointRouteParameters
    {
        public static readonly string[] LatituteParameters = new string[] { "lat", "latitude" };
        public static readonly string[] LongitudeParameters = new string[] { "long", "longitude" };
    }
}
