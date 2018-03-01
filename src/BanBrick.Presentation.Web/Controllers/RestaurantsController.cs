using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BanBirck.Domain.Models.Geometry;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/restaurants/4baa59a8-1d60-11e8-b467-0ed5f89f718b
        [HttpGet("{id:Guid}")]
        public string Get([FromRoute] Guid id)
        {
            return "value";
        }

        // GET: api/restaurants/lat=40.741895&long=-73.989308
        [HttpGet("{location:GeoPoint}")]
        public string Get([FromRoute] GeoPoint location)
        {
            return $"value {location.Latitude} {location.Longitude}";
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
