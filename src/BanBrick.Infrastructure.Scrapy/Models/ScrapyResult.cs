﻿using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Services.Scraping.Models
{
    public class ScrapyResult
    {
        public ScrapyResult()
        {
            SubResults = new List<ScrapyResult>();
            InternalResponse = new ScrapyHttpResponse();
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Result { get; }

        public ScrapyHttpResponse InternalResponse { get; set; }

        public ScrapyResultType Type { get; set; }

        public List<ScrapyResult> SubResults { get; set; }
    }
}
