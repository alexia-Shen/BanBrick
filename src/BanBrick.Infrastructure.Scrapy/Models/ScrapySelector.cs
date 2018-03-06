using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Services.Scraping.Models
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
        
        public bool AddToParameters { get; set; }

        public SelectorSourceType SelectorSourceType { get; set; }

        public ScrapyResultType ScrapyResultType { get; set; }
        
        public IList<ScrapySelector> SubSelectors { get; set; }
    }
}
