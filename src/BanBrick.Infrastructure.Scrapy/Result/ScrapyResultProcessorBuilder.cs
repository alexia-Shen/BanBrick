using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public static class ScrapyResultProcessorBuilder
    {
        public static IDictionary<SelectorSourceType, IScrapyResultProcesser> Processers { get; set; }
    }
}
