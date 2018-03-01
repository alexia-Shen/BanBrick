using BanBirck.Domain.Models.Geometry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanBrick.Presentation.Web.RouteConfigs
{
    public class GeoPointRouteConstaint : IRouteConstraint
    {
        public static readonly KeyValuePair<string, Type> ConstraintMap = new KeyValuePair<string, Type>("GeoPoint", typeof(GeoPointRouteConstaint));
        
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            if (route == null)
            {
                throw new ArgumentNullException(nameof(route));
            }

            if (routeKey == null)
            {
                throw new ArgumentNullException(nameof(routeKey));
            }

            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            var queryParameters = ((string)values[routeKey]).Split("&").Select(x => x.Split("="));
            var containslatitude = ContainsParameter(GeoPointRouteParameters.LatituteParameters, queryParameters);
            var containslongitude = ContainsParameter(GeoPointRouteParameters.LongitudeParameters, queryParameters);
            
            return containslatitude & containslongitude;
        }

        private bool ContainsParameter(string[] parameterNames, IEnumerable<string[]> queryParameters)
        {
            return queryParameters.Any(x => parameterNames.Contains(x[0], StringComparer.CurrentCultureIgnoreCase));
        }
    }
}
