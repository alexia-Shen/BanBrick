using BanBrick.Domain.Models.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Domain.Services
{
    public interface IRestaurantServices
    {
        IEnumerable<Restaurant> GetRestaurants(RestaurantQuery query);
    }
}
