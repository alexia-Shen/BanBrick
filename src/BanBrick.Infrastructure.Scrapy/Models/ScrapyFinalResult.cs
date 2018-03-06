using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyFinalResult
    {
        public List<ScrapyProcessResult> Results { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
    }
}
