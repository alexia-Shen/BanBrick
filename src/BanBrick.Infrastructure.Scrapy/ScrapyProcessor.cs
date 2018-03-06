using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Infrastructure.Scrapy.Result;
using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy
{
    public class ScrapyProcessor
    {
        private ScrapyHttpProcesser _scrapyHttpProcesser;
        private ScrapyResultProcesser _scrapyResultProcesser;

        public ScrapyProcessor() {
            _scrapyHttpProcesser = new ScrapyHttpProcesser();
            _scrapyResultProcesser = new ScrapyResultProcesser();
        }

        public ScrapyFinalResult Process(ScrapyConfiguration scrapingConfiguration, IDictionary<string, string> paramters)
        {
            var defualtHeaders = new List<HttpHeader>();

            if (scrapingConfiguration.UseBrowserEmulator == true)
                defualtHeaders.AddRange(GetEmulateHeaders());

            var processedReuslts = new List<ScrapyProcessResult>();

            foreach (var scrapyMethod in scrapingConfiguration.ScrapyMethods)
            {
                var processedReuslt = Process(scrapyMethod, defualtHeaders, processedReuslts, paramters);
                processedReuslts.AddRange(processedReuslt.Results);
            }

            return null;
        }

        public ScrapyFinalResult Process(ScrapyMethod scrapyMethod, IList<HttpHeader> defualtHeaders,
            IList<ScrapyProcessResult> processedResults, IDictionary<string, string> paramters)
        {
            var response = _scrapyHttpProcesser.Process(scrapyMethod, defualtHeaders, processedResults, paramters);
            var result = _scrapyResultProcesser.Process(response, scrapyMethod.Selector);
            
            return result;
        }
        
        private HttpHeader[] GetEmulateHeaders()
        {
            var connection = new HttpHeader("Connection", "keep-alive");
            var userAgent = new HttpHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36");
            var accept = new HttpHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            var acceptEncoding = new HttpHeader("Accept-Encoding", "gzip, deflate");
            var acceptLanguage = new HttpHeader("Accept-Language", "en-GB,en;q=0.9,en-US;q=0.8,zh-CN;q=0.7,zh;q=0.6,zh-TW;q=0.5");

            return new HttpHeader[] { connection, userAgent, accept, acceptEncoding, acceptLanguage };
        }
    }
}
