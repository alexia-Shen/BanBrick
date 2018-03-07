using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyMethod
    {
        public ScrapyMethod() {
            Selectors = new List<ScrapySelector>();
        }

        public string Name { get; set; }

        public HttpMethod HttpMethod { get; set; }

        public string RequestHost { get; set; }

        public string RequestUriTemplate { get; set; }

        public string RequestHeaderTemplate { get; set; }

        public string RequestContentTemplate { get; set; }

        public List<ScrapySelector> Selectors { get; set; }

        public ScrapyMethod NextMethod { get; set; }
    }
}
