using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BanBrick.Services.Scraping.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultJsonProcesser : IScrapyResultProcesser
    {
        public List<ScrapyResult> Process(string content, ScrapySelector selector)
        {
            throw new NotImplementedException();
        }

        public List<ScrapyResult> Process(HttpResponseMessage response, ScrapySelector selector)
        {
            throw new NotImplementedException();
        }
    }
}
