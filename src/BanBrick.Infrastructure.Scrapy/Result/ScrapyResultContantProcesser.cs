using System;
using System.Collections.Generic;
using System.Text;
using BanBrick.Services.Scraping.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultContantProcesser : IScrapyResultProcesser
    {
        public List<ScrapyResult> Process(string content, ScrapySelector selector)
        {
            throw new NotImplementedException();
        }
    }
}
