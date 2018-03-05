﻿using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Services.Scraping.Models
{
    public class ScrapyResult
    {
        public string Name { get; set; }

        public string Value { get; set; }

        public ScrapyResultType ScrapyResultType { get; set; }

        public IList<ScrapyResult> SubResults { get; set; }
    }
}
