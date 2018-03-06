using BanBrick.Services.Scraping.Enums;
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

        public IList<ScrapyMethod> ScrapyMethods { get; set; }
        
        public bool UseBrowserEmulator { get; set; }
    }
}
