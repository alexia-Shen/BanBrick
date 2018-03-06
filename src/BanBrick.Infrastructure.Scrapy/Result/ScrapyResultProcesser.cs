using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Services.Scraping.Enums;
using BanBrick.Services.Scraping.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultProcesser
    {
        private ScrapyResultProcessorBuilder _scrapyResultProcessorBuilder;

        public ScrapyResultProcesser()
        {
            _scrapyResultProcessorBuilder = new ScrapyResultProcessorBuilder();
        }

        public List<ScrapyResult> Process(ScrapyHttpResponse response, ScrapySelector selector)
        {
            var processor = _scrapyResultProcessorBuilder.Processers[selector.SelectorSourceType];
            var results = processor.Process(response, selector);

            if (selector.SubSelectors.Count > 0)
            {
                foreach (var subSelector in selector.SubSelectors)
                {
                    foreach (var result in results)
                    {
                        result.SubResults.AddRange(Process(result.InternalResponse, subSelector));
                    }
                }
            }

            return results;
        }
    }
}
