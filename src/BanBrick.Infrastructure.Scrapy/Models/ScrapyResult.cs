using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyResult
    {
        public ScrapyResult() {
            Results = new List<ScrapyProcessResult>();
            Parameters = new Dictionary<string, string>();
        }

        public string Name { get; set; }

        public List<ScrapyProcessResult> Results { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
