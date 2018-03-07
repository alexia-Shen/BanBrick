using BanBrick.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyResponse
    {
        public ScrapyResponse() {
            HttpHeaders = new List<HttpHeader>();
        }

        public ScrapyResponse(string content)
        {
            BodyContent = content;
        }

        public ScrapyResponse(string content, List<HttpHeader> httpHeaders): this(content)
        {
            HttpHeaders = httpHeaders;
        }

        public ScrapyResponse(HttpResponseMessage httpResponseMessage) : this()
        {
            BodyContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            HttpHeaders = httpResponseMessage.Headers.Select(x => new HttpHeader(x.Key, string.Join("; ", x.Value))).ToList();
        }

        public List<HttpHeader> HttpHeaders { get; set; }

        public string BodyContent { get; set; }
    }
}
