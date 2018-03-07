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

        public Dictionary<string, ScrapyResult> Process(ScrapyConfiguration scrapingConfiguration, IDictionary<string, string> paramters, IEnumerable<HttpHeader> defaultHeaders)
        {
            var reuslts = new Dictionary<string, ScrapyResult>();
            
            _httpProcessor.Host = scrapingConfiguration.Host;

            foreach (var scrapyMethod in scrapingConfiguration.ScrapyMethods)
            {
                reuslts[scrapyMethod.Name] = Process(scrapyMethod, paramters, defaultHeaders);
            }

            return reuslts;
        }

        public ScrapyResult Process(ScrapyMethod scrapyMethod, IDictionary<string, string> paramters, IEnumerable<HttpHeader> defaultHeaders)
        {
            var response = _httpProcessor.Process(scrapyMethod, paramters, defaultHeaders);
            var result = _resultProcessor.Process(response, scrapyMethod.Selector);

            if (scrapyMethod.NextMethod != null)
            {
                var nextParameters = new Dictionary<string, string>();

                foreach (var parameter in paramters)
                {
                    nextParameters[parameter.Key] = parameter.Value;
                }

                foreach (var parameter in result.Parameters)
                {
                    nextParameters[parameter.Key] = parameter.Value;
                }

                result = Process(scrapyMethod.NextMethod, nextParameters, defaultHeaders);
            }
            
            return result;
        }
    }
}
