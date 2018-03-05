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

        public ScrapyResultProcesser() {
            _scrapyResultProcessorBuilder = new ScrapyResultProcessorBuilder();
        }

        public List<ScrapyResult> Process(HttpResponseMessage response, ScrapySelector selector)
        {
            var results = _scrapyResultProcessorBuilder.Processers[selector.SelectorSourceType].Process(response, selector);

            if (selector.SubSelectors.Count > 0)
            {
                foreach (var subSelector in selector.SubSelectors)
                {
                    foreach (var result in results)
                    {
                        var responseMessage = new HttpResponseMessage(HttpStatusCode.OK) {
                            Content = new StringContent(result.Value)
                        };
                        result.SubResults.AddRange(Process(responseMessage, subSelector));
                    }
                }
            }

            return results;
        }
    }
}
