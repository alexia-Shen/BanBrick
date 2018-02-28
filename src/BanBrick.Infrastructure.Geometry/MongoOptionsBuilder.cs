using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Geometry
{
    public class MongoSettingsBuilder
    {
        private MongoOptions _options;

        public MongoSettingsBuilder() {
            _options = new MongoOptions();
        }

        public MongoSettingsBuilder(Action<MongoSettingsBuilder> optionsAction): this()
        {
            optionsAction(this);
        }

        public MongoOptions Options => _options;
        
        public void UseMongo(string connectionString) {
            _options = new MongoOptions(connectionString);
        }
    }
}
