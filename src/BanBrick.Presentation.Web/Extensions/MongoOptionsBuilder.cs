using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanBrick.Presentation.Web.Extensions
{
    public class MongoOptionsBuilder
    {
        public string Connection {get;set;}

        public void UseConnection(string connectionString) {
            Connection = connectionString;
        }
    }
}
