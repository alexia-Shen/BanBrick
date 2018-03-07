using BanBrick.Infrastructure.Scrapy.HttpProcess;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy
{
    public class ScrapyConfigs
    {
        public ScrapyConfigs() {
            TemplateProcessor = new ScrapyTemplateProcessor();
        }

        public IScrapyTemplateProcessor TemplateProcessor { get; set; }
    }
}
