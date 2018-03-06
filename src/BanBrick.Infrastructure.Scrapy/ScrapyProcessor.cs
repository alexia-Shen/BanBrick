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
        public ScrapyFinalResult Process(ScrapyConfiguration scrapingConfiguration, IDictionary<string, string> paramters)
        {
            var defualtHeaders = new List<HttpHeader>();

            if (scrapingConfiguration.UseBrowserEmulator == true)
                defualtHeaders.AddRange(GetEmulateHeaders());

            var processedReuslts = new List<ScrapyProcessResult>();
            var autoDecompress = defualtHeaders.Any(x => x.Name.Equals("Accept-Encoding", StringComparison.CurrentCultureIgnoreCase));

            using (var httpClient = new BanBrickHttpClient(scrapingConfiguration.Host, autoDecompress))
            {
                var httpProcesser = new ScrapyHttpProcesser(httpClient);
                var resultProcesser = new ScrapyResultProcesser();

                foreach (var scrapyMethod in scrapingConfiguration.ScrapyMethods)
                {
                    var processedReuslt = Process(httpProcesser, resultProcesser, scrapyMethod, defualtHeaders, paramters);

                    processedReuslts.AddRange(processedReuslt.Results);
                }
            }
            return null;
        }

        public ScrapyFinalResult Process(ScrapyHttpProcesser httpProcesser, ScrapyResultProcesser resultProcesser,
            ScrapyMethod scrapyMethod, IList<HttpHeader> defualtHeaders, IDictionary<string, string> paramters)
        {
            var response = httpProcesser.Process(scrapyMethod, defualtHeaders, paramters);
            var result = resultProcesser.Process(response, scrapyMethod.Selector);

            if (scrapyMethod.NextScrapyMethod != null)
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

                result = Process(httpProcesser, resultProcesser, scrapyMethod.NextScrapyMethod, defualtHeaders,  nextParameters);
            }

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
