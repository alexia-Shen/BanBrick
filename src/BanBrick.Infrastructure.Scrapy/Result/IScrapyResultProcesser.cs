using BanBrick.Services.Scraping.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public interface IScrapyResultProcesser
    {
        ScrapyResult Process(HttpResponseMessage httpResponseMessage, ScrapySelector selector);
    }
}
