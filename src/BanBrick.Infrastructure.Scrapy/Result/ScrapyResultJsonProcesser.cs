using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Services.Scraping.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultJsonProcesser : IScrapyResultProcesser
    {
        public List<ScrapyResult> Process(ScrapyHttpResponse content, ScrapySelector selector)
        {
            throw new NotImplementedException();
        }
    }
}
