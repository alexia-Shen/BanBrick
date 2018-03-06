using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using BanBrick.Infrastructure.Scrapy.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultHeaderProcesser : IScrapyResultProcesser
    {
        public List<ScrapyProcessResult> Process(ScrapyHttpResponse response, ScrapySelector selector)
        {
            var results = new List<ScrapyProcessResult>();

            foreach (var header in response.Headers)
            {
                results.Add(new ScrapyProcessResult()
                {
                    Name = header.Name,
                    Value = header.Value,
                    Type = selector.ScrapyResultType
                });
            }

            return results;
        }
    }
}
