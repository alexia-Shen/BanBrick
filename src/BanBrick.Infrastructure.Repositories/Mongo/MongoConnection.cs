using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Repositories.Mongo
{
    public class MongoConnection
    {
        public string ConnectionString { get; set; }

        public string Database { get; set; }
    }
}
