using BanBrick.Infrastructure.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapySelector
    {
        public ScrapySelector()
        {
            SubSelectors = new List<ScrapySelector>();
        }

        public string Query { get; set; }

        public string Name { get; set; }

        public string Regex { get; set; }
        
        public bool IsParameter { get; set; }

        public bool IsSingle { get; set; }

        public ScrapySourceType SourceType { get; set; }
        
        public ScrapyResultType ResultType { get; set; }

        public List<ScrapySelector> SubSelectors { get; set; }
    }
}
