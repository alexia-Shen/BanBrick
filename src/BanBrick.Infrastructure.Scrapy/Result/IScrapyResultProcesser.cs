using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Services.Scraping.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public interface IScrapyResultProcesser
    {
        List<ScrapyResult> Process(ScrapyHttpResponse response, ScrapySelector selector);
    }
}
