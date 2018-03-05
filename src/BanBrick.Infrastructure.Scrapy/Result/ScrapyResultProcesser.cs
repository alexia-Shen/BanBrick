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

        public List<ScrapyResult> Process(string content, ScrapySelector selector)
        {
            var results = _scrapyResultProcessorBuilder.Processers[selector.SelectorSourceType].Process(content, selector);

            if (selector.SubSelectors.Count > 0)
            {
                foreach (var subSelector in selector.SubSelectors)
                {
                    foreach (var result in results)
                    {
                        result.SubResults.AddRange(Process(result.Value, subSelector));
                    }
                }
            }

            return results;
        }
    }
}
