using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanBirck.Domain.Models.Geometry;
using BanBrick.Domain.Models.Presentation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BanBrick.Presentation.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
        // GET: api/restaurants
        [HttpGet]
        public IEnumerable<Restaurant> Get([FromQuery] RestaurantQuery query)
        {
            return null;
        }

        // GET: api/restaurants/4baa59a8-1d60-11e8-b467-0ed5f89f718b
        [HttpGet("{id:Guid}")]
        public Restaurant Get([FromRoute] Guid id)
        {
            return null;
        }

        // POST: api/Restaurants
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
