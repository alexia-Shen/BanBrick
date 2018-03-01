using BanBirck.Domain.Models.Geometry;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanBrick.Presentation.Web.RouteConfigs
{
    public class GeoPointModelBinder : IModelBinder
    {
        private ModelBinderProviderContext _context;

        public GeoPointModelBinder(ModelBinderProviderContext context)
        {
            _context = context;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (bindingContext.ModelMetadata.ModelType == typeof(GeoPoint))
            {
                var queryValue = bindingContext.ValueProvider.GetValue(bindingContext.FieldName).FirstValue;

                bindingContext.Result = ModelBindingResult.Success(GetGeoPoint(queryValue));
            }

            return Task.CompletedTask;
        }

        private GeoPoint GetGeoPoint(string query)
        {
            var coordinates = query.Split("&").Select(x => x.Split("="));

            var latitude = GetCoordinateValue(GeoPointRouteParameters.LatituteParameters, coordinates);
            var longitude = GetCoordinateValue(GeoPointRouteParameters.LongitudeParameters, coordinates);

            return new GeoPoint(latitude, longitude);
        }

        private double GetCoordinateValue(string[] parameterNames, IEnumerable<string[]> coordinates)
        {
            var coordinate = coordinates.FirstOrDefault(x => parameterNames.Contains(x[0], StringComparer.CurrentCultureIgnoreCase));
            
            if (coordinate != null)
                return double.Parse(coordinate[1]);
            return 0;
        }
    }
}
