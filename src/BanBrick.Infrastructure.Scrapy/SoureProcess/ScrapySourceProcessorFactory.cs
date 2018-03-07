using BanBrick.Infrastructure.Scrapy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.SourceProcess
{
    public class ScrapySourceProcessorFactory
    {
        public ScrapySourceProcessorFactory() {
            Processors = new Dictionary<ScrapySourceType, IScrapySourceProcessor>();

            Processors[ScrapySourceType.Html] = new ScrapyHtmlSourceProcessor();
            Processors[ScrapySourceType.Json] = new ScrapyContantSourceProcessor();
            Processors[ScrapySourceType.Constant] = new ScrapyJsonSourceProcessor();
            Processors[ScrapySourceType.Header] = new ScrapyHeaderSourceProcessor();
        }
        
        public IDictionary<ScrapySourceType, IScrapySourceProcessor> Processors { get; set; }
    }
}
