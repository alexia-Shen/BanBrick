using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyProcessResult
    {
        public ScrapyProcessResult()
        {
            SubResults = new List<ScrapyProcessResult>();
            InternalResponse = new ScrapyHttpResponse();
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Result { get; }

        public ScrapyHttpResponse InternalResponse { get; set; }

        public ScrapyResultType Type { get; set; }

        public List<ScrapyProcessResult> SubResults { get; set; }
    }
}
