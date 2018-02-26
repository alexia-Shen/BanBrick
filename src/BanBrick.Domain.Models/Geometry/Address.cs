using System;
using System.Collections.Generic;
using System.Text;

namespace BanBirck.Domain.Models.Geometry
{
    public class Address
    {
        public string Unit { get; set; }

        public string StreetNumber { get; set; }

        public string StreetName { get; set; }

        public string StreetType { get; set; }

        public Suburb Suburb { get; set; }
    }
}
