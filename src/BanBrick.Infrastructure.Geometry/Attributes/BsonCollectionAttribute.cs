using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Geometry.Attributes
{
    public class BsonCollectionAttribute: Attribute
    {
        public BsonCollectionAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
