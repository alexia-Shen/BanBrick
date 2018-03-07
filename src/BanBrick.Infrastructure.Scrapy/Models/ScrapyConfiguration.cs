using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapyConfiguration
    {
        public ScrapyConfiguration()
        {
            ScrapyMethods = new List<ScrapyMethod>();
        }

        public string Host;

        public List<ScrapyMethod> ScrapyMethods { get; set; }
    }
}
