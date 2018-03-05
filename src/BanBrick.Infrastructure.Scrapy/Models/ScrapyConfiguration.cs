using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Services.Scraping.Models
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
