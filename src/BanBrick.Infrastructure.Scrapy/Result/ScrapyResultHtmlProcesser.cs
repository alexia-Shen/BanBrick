using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BanBrick.Services.Scraping.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultHtmlProcesser : IScrapyResultProcesser
    {
        public ScrapyResult Process(HttpResponseMessage httpResponseMessage, ScrapySelector selector)
        {
            var result = new ScrapyResult() { Name = selector.Name };
            

            return result;
        }
    }
}
