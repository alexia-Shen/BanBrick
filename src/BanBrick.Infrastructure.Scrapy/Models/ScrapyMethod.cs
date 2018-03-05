using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Services.Scraping.Models
{
    public class ScrapyMethod
    {
        public HttpMethod HttpMethod { get; set; }

        public string RequestHost { get; set; }

        public string RequestUriTemplate { get; set; }

        public string RequestHeaderTemplate { get; set; }

        public string RequestContentTemplate { get; set; }

        public ScrapySelector Selector { get; set; }

        public ScrapyMethod NextScrapyMethod { get; set; }
    }
}
