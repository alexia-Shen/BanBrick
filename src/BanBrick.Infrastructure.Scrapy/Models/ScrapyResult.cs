using BanBrick.Infrastructure.Scraping.Enums;
using System;
using System.Collections.Generic;
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
    }
}
