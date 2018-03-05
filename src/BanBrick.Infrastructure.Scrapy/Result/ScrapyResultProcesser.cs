using BanBrick.Services.Scraping.Enums;
using BanBrick.Services.Scraping.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultProcesser
    {
        public ScrapyResult Process(HttpResponseMessage httpResponseMessage, ScrapySelector selector)
        {
            switch (selector.SelectorSourceType)
            {
                case SelectorSourceType.Constant: break;
                case SelectorSourceType.Html:
                    return ProcessHtmlResponse(httpResponseMessage, selector);

                case SelectorSourceType.Json: break;
            }

            return null;
        }

        private ScrapyResult ProcessConstantResponse(HttpResponseMessage httpResponseMessage, ScrapySelector selector)
        {
            return null;
        }

        private ScrapyResult ProcessHtmlResponse(HttpResponseMessage httpResponseMessage, ScrapySelector selector)
        {
            switch (selector.SelectorResultType)
            {
                case SelectorResultType.List: break;
                case SelectorResultType.Object: break;
                case SelectorResultType.Property: break;
            }

            return null;
        }

        private ScrapyResult ProcessJsonResponse(HttpResponseMessage httpResponseMessage, ScrapySelector selector)
        {
            return null;
        }
    }
}
