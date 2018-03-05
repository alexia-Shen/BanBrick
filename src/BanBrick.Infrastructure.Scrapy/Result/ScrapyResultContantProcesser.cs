using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BanBrick.Services.Scraping.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultContantProcesser : IScrapyResultProcesser
    {
        public ScrapyResult Process(HttpResponseMessage httpResponseMessage, ScrapySelector selector)
        {
            throw new NotImplementedException();
        }
    }
}
