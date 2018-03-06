using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultProcessorFactory
    {
        public ScrapyResultProcessorFactory() {
            Processers = new Dictionary<object, IScrapyResultProcesser>();

            Processers[SelectorSourceType.Html] = new ScrapyResultHtmlProcesser();
            Processers[SelectorSourceType.Json] = new ScrapyResultContantProcesser();
            Processers[SelectorSourceType.Constant] = new ScrapyResultJsonProcesser();
            Processers[SelectorSourceType.Header] = new ScrapyResultHeaderProcesser();
        }
        
        public Dictionary<object, IScrapyResultProcesser> Processers { get; set; }
    }
}
