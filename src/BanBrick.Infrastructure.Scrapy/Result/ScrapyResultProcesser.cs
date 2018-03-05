using BanBrick.Services.Scraping.Enums;
using BanBrick.Services.Scraping.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultProcesser
    {
        private ScrapyResultProcessorBuilder _scrapyResultProcessorBuilder;

        public ScrapyResultProcesser() {
            _scrapyResultProcessorBuilder = new ScrapyResultProcessorBuilder();
        }

        public ScrapyResult Process(HttpResponseMessage httpResponseMessage, ScrapySelector selector)
        {
            var result = _scrapyResultProcessorBuilder.Processers[selector.SelectorSourceType].Process(httpResponseMessage, selector);
            return null;
        }
    }
}
