using BanBrick.Infrastructure.Scrapy.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.SourceProcess
{
    public interface IScrapySourceProcessor
    {
        List<ScrapyResult> Process(ScrapyResponse response, ScrapySelector selector);
    }
}
