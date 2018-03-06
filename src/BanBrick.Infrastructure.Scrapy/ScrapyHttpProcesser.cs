using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Scrapy.Models;
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
        private BanBrickHttpClient _banBrickHttpClient;

        public ScrapyHttpProcesser(BanBrickHttpClient banBrickHttpClient)
        {
            _banBrickHttpClient = banBrickHttpClient;
        }

        /// <summary>
        /// Process ScrapyMethod
        /// </summary>
        /// <param name="scrapyMethod"></param>
        /// <param name="defualtHeaders"></param>
        /// <param name="processedResults"></param>
        /// <param name="paramters"></param>
        /// <returns>HttpResponseMessage String Content</returns>
        public ScrapyHttpResponse Process(ScrapyMethod scrapyMethod, IList<HttpHeader> defualtHeaders, IDictionary<string, string> paramters)
        {
            var requstUri = ProcessStringTemplate(scrapyMethod.RequestUriTemplate, paramters);
            var requestContent = ProcessRequestContentTemplate(scrapyMethod.RequestContentTemplate, paramters);
            var requestHeaders = ProcessRequestHeaderTemplate(scrapyMethod.RequestHeaderTemplate, paramters);

            if (defualtHeaders != null)
            {
                var addtionalRequestHeaders = defualtHeaders.Where(x => !requestHeaders.Any(y => y.Name == x.Name)).ToList();
                requestHeaders.AddRange(addtionalRequestHeaders);
            }

            return new ScrapyHttpResponse(_banBrickHttpClient.Send(scrapyMethod.HttpMethod, requstUri, requestHeaders.ToArray(), requestContent));
        }

        private HttpContent ProcessRequestContentTemplate(string template, IDictionary<string, string> parameters)
        {
            var contentString = ProcessStringTemplate(template, parameters);

            try
            {
                var json = new JObject(contentString);
            }
            catch (Exception ex)
            {

            }

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
