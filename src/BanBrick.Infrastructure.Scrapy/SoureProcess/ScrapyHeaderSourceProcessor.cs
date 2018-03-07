using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using BanBrick.Infrastructure.Scrapy.Models;

namespace BanBrick.Infrastructure.Scrapy.SourceProcess
{
    public class ScrapyHeaderSourceProcessor : IScrapySourceProcessor
    {
        public List<ScrapyResult> Process(ScrapyResponse response, ScrapySelector selector)
        {
            var results = new List<ScrapyResult>();

            foreach (var header in response.HttpHeaders)
            {
                results.Add(new ScrapyResult()
                {
                    Name = header.Name,
                    Value = header.Value,
                    ResultType = selector.ResultType
                });
            }

            return results;
        }
    }
}
