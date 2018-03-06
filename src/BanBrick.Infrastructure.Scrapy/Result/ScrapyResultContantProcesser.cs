using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BanBrick.Infrastructure.Scrapy.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultContantProcesser : IScrapyResultProcesser
    {
        public List<ScrapyProcessResult> Process(ScrapyHttpResponse content, ScrapySelector selector)
        {
            throw new NotImplementedException();
        }
    }
}
