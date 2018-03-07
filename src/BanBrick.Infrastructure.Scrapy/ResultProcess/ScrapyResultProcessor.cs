using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Infrastructure.Scrapy.SourceProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.ResultProcess
{
    public class ScrapyResultProcessor: IScrapyResultProcessor
    {
        private ScrapySourceProcessorFactory _scrapySourceProcessorBuilder;

        public ScrapyResultProcessor()
        {
            _scrapySourceProcessorBuilder = new ScrapySourceProcessorFactory();
        }
        
        public ScrapyResult Process(ScrapyResponse response, ScrapySelector selector)
        {
            var results = GetResults(response, selector);
            var parameters = GetParameters(results, selector);

            return new ScrapyResult()
            {
                SubResults = results,
                Parameters = parameters,
                Name = selector.Name
            };
        }
        
        private List<ScrapyResult> GetResults(ScrapyResponse response, ScrapySelector selector)
        {
            // get source Processor
            var processor = _scrapySourceProcessorBuilder.Processors[selector.SourceType];

            var results = processor.Process(response, selector).ToList();

            if (selector.SubSelectors.Count() > 0)
            {
                foreach (var result in results)
                {
                    foreach (var subSelector in selector.SubSelectors)
                    {
                        var subResults = GetResults(result.ProcessedResponse, subSelector);
                        result.SubResults.AddRange(subResults);
                    }
                }
            }

            return results;
        }

        private Dictionary<string, string> GetParameters(IEnumerable<ScrapyResult> results, ScrapySelector selector, string prefix = "")
        {
            var parameters = new Dictionary<string, string>();
            
            foreach (var result in results)
            {
                var parentName = !string.IsNullOrEmpty(prefix) ? $"{prefix}." : "";
                var parameterName = $"{parentName}{result.Name}";

                if (selector.IsParameter == true)
                {
                    parameters[parameterName] = result.Value;
                }

                foreach (var subSelector in selector.SubSelectors)
                {
                    var subParameters = GetParameters(result.SubResults, subSelector, parameterName);

                    foreach (var subParameter in subParameters)
                    {
                        parameters[subParameter.Key] = subParameter.Value;
                    }
                }
            }

            
            return parameters;
        }
    }
}
