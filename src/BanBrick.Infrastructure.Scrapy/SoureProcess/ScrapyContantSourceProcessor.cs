using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BanBrick.Infrastructure.Scrapy.Models;

namespace BanBrick.Infrastructure.Scrapy.SourceProcess
{
    public class ScrapyContantSourceProcessor : IScrapySourceProcessor
    {
        public List<ScrapyResult> Process(ScrapyResponse content, ScrapySelector selector)
        {
            throw new NotImplementedException();
        }
    }
}
