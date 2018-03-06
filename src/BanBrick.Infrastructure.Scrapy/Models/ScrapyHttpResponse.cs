using BanBrick.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyHttpResponse
    {
        public ScrapyHttpResponse() {
            Headers = new List<HttpHeader>();
        }

        public ScrapyHttpResponse(string content)
        {
            Content = content;
        }

        public ScrapyHttpResponse(HttpResponseMessage httpResponseMessage) : this()
        {
            Content = httpResponseMessage.Content.ReadAsStringAsync().Result;
            Headers = httpResponseMessage.Headers.Select(x => new HttpHeader(x.Key, string.Join("; ", x.Value))).ToList();
        }

        public List<HttpHeader> Headers { get; set; }
        public string Content { get; set; }
    }
}
