using BanBrick.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Domain.Models.Presentation
{
    public class RestaurantDeliveryService
    {
        public string Name { get; set; }

        public string Url { get; set; }
        
        public IEnumerable<Tag> Tags { get; set; }
    }
}
