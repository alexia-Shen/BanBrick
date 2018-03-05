using BanBrick.Infrastructure.Http;
using BanBrick.Services.Scraping.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy
{
    public class ScrapyHttpProcesser
    {
        /// <summary>
        /// Process ScrapyMethod
        /// </summary>
        /// <param name="scrapyMethod"></param>
        /// <param name="defualtHeaders"></param>
        /// <param name="processedResults"></param>
        /// <param name="paramters"></param>
        /// <returns>HttpResponseMessage String Content</returns>
        public HttpResponseMessage Process(ScrapyMethod scrapyMethod, IList<HttpHeader> defualtHeaders,
            IList<ScrapyResult> processedResults, IDictionary<string, string> paramters)
        {
            var autoDecompress = defualtHeaders.Any(x => x.Name.Equals("Accept-Encoding", StringComparison.CurrentCultureIgnoreCase));

            var requstUri = ProcessStringTemplate(scrapyMethod.RequestUriTemplate, paramters);
            var requestContent = ProcessRequestContentTemplate(scrapyMethod.RequestContentTemplate, paramters);
            var requestHeaders = ProcessRequestHeaderTemplate(scrapyMethod.RequestHeaderTemplate, paramters);

            if (defualtHeaders != null)
            {
                var addtionalRequestHeaders = defualtHeaders.Where(x => !requestHeaders.Any(y => y.Name == x.Name)).ToList();
                requestHeaders.AddRange(addtionalRequestHeaders);
            }
            
            using (var httpClient = new BanBrickHttpClient(scrapyMethod.RequestHost, autoDecompress))
            {
                return httpClient.Send(scrapyMethod.HttpMethod, requstUri, requestHeaders.ToArray(), requestContent);
            }
        }

        private HttpContent ProcessRequestContentTemplate(string template, IDictionary<string, string> parameters)
        {
            var contentString = ProcessStringTemplate(template, parameters);
            return new StringContent(contentString, Encoding.UTF8, "application/json");
        }

        private List<HttpHeader> ProcessRequestHeaderTemplate(string template, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(template))
                return new List<HttpHeader>();

            var headerString = ProcessStringTemplate(template, parameters);
            var requestHeaders = JObject.Parse(headerString).Properties().Select(x => new HttpHeader(x.Name, x.Value.ToString())).ToList();

            return requestHeaders;
        }

        private string ProcessStringTemplate(string template, IDictionary<string, string> parameters)
        {
            var result = template ?? "";

            foreach (var parameter in parameters)
            {
                result = result.Replace("{{" + parameter.Key + "}}", parameter.Value);
            }

            return result;
        }
    }
}
