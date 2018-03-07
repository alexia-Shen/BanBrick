using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Scrapy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.HttpProcess
{
    public interface IScrapyHttpProcessor: IDisposable
    {
        string Host { get; set; }

        ScrapyResponse Process(ScrapyMethod scrapyMethod, IDictionary<string, string> paramters, IEnumerable<HttpHeader> defualtHeaders);
    }
}
