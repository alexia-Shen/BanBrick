using System;
using System.Collections.Generic;
using System.Text;
using BanBrick.Domain.Models.Presentation;

namespace BanBrick.Domain.Services
{
    public class RestaurantServices: IRestaurantServices
    {
        public RestaurantServices()
        {

        }

        public IEnumerable<Restaurant> GetRestaurants(RestaurantQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
