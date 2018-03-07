using BanBrick.Infrastructure.Scraping.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyResult
    {
        public ScrapyResult() {
            SubResults = new List<ScrapyResult>();
            Parameters = new Dictionary<string, string>();
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public ScrapyResponse ProcessedResponse { get; set; }

        public ScrapyResultType ResultType { get; set; }

        public Dictionary<string, string> Parameters { get; set; }

        public List<ScrapyResult> SubResults { get; set; }

        public object ToJson() {
            switch (ResultType)
            {
                case ScrapyResultType.Property:
                    return new JProperty(Name, Value);
                case ScrapyResultType.Object:
                    return new JObject(SubResults.Select(x => x.ToJson()));
                case ScrapyResultType.List:
                    return new JArray(SubResults.Select(x => x.ToJson()));
            }

            return null;
        }
    }
}
