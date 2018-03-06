using BanBrick.Infrastructure.Scrapy.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultProcesser
    {
        private ScrapyResultProcessorFactory _scrapyResultProcessorBuilder;

        public ScrapyResultProcesser()
        {
            _scrapyResultProcessorBuilder = new ScrapyResultProcessorFactory();
        }

        public ScrapyResult Process(ScrapyHttpResponse response, ScrapySelector selector)
        {
            var results = ProcessResults(response, selector);
            var parameters = ProcessParameters(results, selector);

            return new ScrapyResult()
            {
                Results = results,
                Parameters = parameters,
                Name = selector.Name
            };
        }

        public List<ScrapyResult> Process(ScrapyHttpResponse response, List<ScrapySelector> selectors)
        {
            var results = new List<ScrapyResult>();

            foreach (var selector in selectors)
            {
                results.Add(Process(response, selector));
            }

            return results;
        }

        private List<ScrapyProcessResult> ProcessResults(ScrapyHttpResponse response, ScrapySelector selector)
        {
            var processor = _scrapyResultProcessorBuilder.Processers[selector.SelectorSourceType];
            var results = processor.Process(response, selector);

            if (selector.SubSelectors.Count > 0)
            {
                foreach (var subSelector in selector.SubSelectors)
                {
                    foreach (var result in results)
                    {
                        result.SubResults.AddRange(ProcessResults(result.InternalResponse, subSelector));
                    }
                }
            }

            return results;
        }

        private Dictionary<string, string> ProcessParameters(List<ScrapyProcessResult> results, ScrapySelector selector)
        {
            var parameters = new Dictionary<string, string>();

            if (selector.SubSelectors.Count > 0)
            {
                foreach (var subSelector in selector.SubSelectors)
                {
                    for (int index = 0; index < results.Count; index++)
                    {
                        var subParameters = ProcessParameters(results[index].SubResults, selector);
                        foreach (var subParameter in subParameters)
                        {
                            parameters[$"{selector.Name}.{subParameter.Key}"] = subParameter.Value;
                        }
                    }
                }
            }

            foreach (var result in results)
            {
                parameters[$"{selector.Name}.{result.Name}"] = result.Value;
            }

            return parameters;
        }
    }
}
