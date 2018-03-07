using BanBrick.Infrastructure.Scrapy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.ResultProcess
{
    public interface IScrapyResultProcessor
    {
        ScrapyResult Process(ScrapyResponse response, ScrapySelector selector);
    }
}
