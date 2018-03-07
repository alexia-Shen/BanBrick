using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Scrapy.ResultProcess;
using BanBrick.Infrastructure.Scrapy.HttpProcess;
using BanBrick.Infrastructure.Scrapy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using BanBrick.Infrastructure.Scraping.Enums;

namespace BanBrick.Infrastructure.Scrapy
{
    public class ScrapyProcessor
    {
        private IScrapyHttpProcessor _httpProcessor;
        private IScrapyResultProcessor _resultProcessor;

        public ScrapyProcessor(IScrapyHttpProcessor httpProcessor, IScrapyResultProcessor resultProcessor)
        {
            _httpProcessor = httpProcessor;
            _resultProcessor = resultProcessor;
        }

        public List<ScrapyResult> Process(ScrapyConfiguration scrapingConfiguration, IDictionary<string, string> paramters, IEnumerable<HttpHeader> defaultHeaders)
        {
            var reuslts = new List<ScrapyResult>();
            
            _httpProcessor.Host = scrapingConfiguration.Host;

            foreach (var scrapyMethod in scrapingConfiguration.ScrapyMethods)
            {
                reuslts.Add(Process(scrapyMethod, paramters, defaultHeaders));
            }

            return reuslts;
        }

        public ScrapyResult Process(ScrapyMethod scrapyMethod, IDictionary<string, string> paramters, IEnumerable<HttpHeader> defaultHeaders)
        {
            var response = _httpProcessor.Process(scrapyMethod, paramters, defaultHeaders);
            var results = _resultProcessor.Process(response, scrapyMethod.Selectors);

            if (scrapyMethod.NextMethod != null)
            {
                var nextParameters = new Dictionary<string, string>();

                foreach (var parameter in paramters)
                {
                    nextParameters[parameter.Key] = parameter.Value;
                }

                foreach (var result in results)
                { 
                    foreach (var parameter in result.Parameters)
                    {
                        nextParameters[parameter.Key] = parameter.Value;
                    }
                }

                results = Process(scrapyMethod.NextMethod, nextParameters, defaultHeaders).SubResults;
            }

            var finalResult = new ScrapyResult()
            {
                Name = scrapyMethod.Name,
                Value = response.BodyContent,
                SubResults = results,
                ResultType = ScrapyResultType.List
            };

            return finalResult;
        }
    }
}
