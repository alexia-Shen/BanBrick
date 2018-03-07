using BanBrick.Infrastructure.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.HttpProcess
{
    public class ScrapyTemplateProcessor: IScrapyTemplateProcessor
    {
        public HttpContent GetContentBody(string template, IDictionary<string, string> parameters)
        {
            var contentString = ProcessTemplate(template, parameters);

            if (string.IsNullOrEmpty(contentString))
                return new StringContent("");

            return new StringContent(contentString, Encoding.UTF8, "application/json");
        }

        public List<HttpHeader> GetHttpHeaders(string template, IDictionary<string, string> parameters)
        {
            if (string.IsNullOrEmpty(template))
                return new List<HttpHeader>();

            var headerString = ProcessTemplate(template, parameters);
            var requestHeaders = JObject.Parse(headerString).Properties().Select(x => new HttpHeader(x.Name, x.Value.ToString())).ToList();

            return requestHeaders;
        }

        public string ProcessTemplate(string template, IDictionary<string, string> parameters)
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
