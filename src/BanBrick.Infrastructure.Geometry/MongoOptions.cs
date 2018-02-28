using BanBrick.Infrastructure.Geometry.Constants;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanBrick.Infrastructure.Geometry
{
    public class MongoOptions
    {
        private Dictionary<string, string> _options;
        
        public MongoOptions()
        {
            MongoClientSettings = new MongoClientSettings();

        }

        public MongoOptions(string connectionString): this()
        {
            _options = GenerateOptions(connectionString);

            MongoClientSettings.Server = GenerateMongoServerAddress(_options);
        }

        public string Host {
            get => _options[MongoSettingConstants.Host];
            set
            {
                _options[MongoSettingConstants.Host] = value;
                MongoClientSettings.Server = GenerateMongoServerAddress(_options);
            }
        }

        public int Port {
            get => int.Parse(_options[MongoSettingConstants.Port]);
            set
            {
                _options[MongoSettingConstants.Port] = value.ToString();
                MongoClientSettings.Server = GenerateMongoServerAddress(_options);
            }
        }

        public string Database {
            get => _options[MongoSettingConstants.Database];
            set {
                _options[MongoSettingConstants.Database] = value;
            }
        }

        public MongoClientSettings MongoClientSettings { get; private set; }

        private Dictionary<string, string> GenerateOptions(string connectionString)
        {
            var options = new Dictionary<string, string>();

            foreach (var setting in connectionString.Split(';'))
            {
                var elements = setting.Split('=');
                var name = elements[0].Trim();
                var value = elements.Length > 1 ? elements[1].Trim() : "";

                var settingName = MongoSettingConstants.Settings.FirstOrDefault(x => x.Equals(name, StringComparison.CurrentCultureIgnoreCase));

                if (settingName == null) continue;

                options[settingName] = value;
            }

            return options;
        }

        private MongoServerAddress GenerateMongoServerAddress(Dictionary<string, string> options)
        {
            if (!options.ContainsKey(MongoSettingConstants.Host))
                throw new Exception("Mongo Options: Host is required");

            if (!options.ContainsKey(MongoSettingConstants.Port))
                return new MongoServerAddress(options[MongoSettingConstants.Host]);

            return new MongoServerAddress(options[MongoSettingConstants.Host], int.Parse(options[MongoSettingConstants.Port]));
        }
    }
}
