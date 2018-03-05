using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultProcessorBuilder
    {
        public ScrapyResultProcessorBuilder() {
            Processers = new Dictionary<object, IScrapyResultProcesser>();

            Processers[SelectorSourceType.Html] = new ScrapyResultHtmlProcesser();
            Processers[SelectorSourceType.Json] = new ScrapyResultContantProcesser();
            Processers[SelectorSourceType.Constant] = new ScrapyResultJsonProcesser();
        }
        
        public Dictionary<object, IScrapyResultProcesser> Processers { get; set; }
    }
}
