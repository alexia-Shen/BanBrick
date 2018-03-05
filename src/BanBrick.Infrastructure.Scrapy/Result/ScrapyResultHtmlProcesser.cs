using System;
using System.Collections.Generic;
using System.Text;
using BanBrick.Services.Scraping.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultHtmlProcesser : IScrapyResultProcesser
    {
        public List<ScrapyResult> Process(string content, ScrapySelector selector)
        {
            var result = new ScrapyResult() { Name = selector.Name };
            

            return null;
        }
    }
}
