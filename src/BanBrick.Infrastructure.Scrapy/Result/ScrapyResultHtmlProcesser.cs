using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using AngleSharp.Parser.Html;
using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Services.Scraping.Enums;
using BanBrick.Services.Scraping.Models;

namespace BanBrick.Infrastructure.Scrapy.Result
{
    public class ScrapyResultHtmlProcesser : IScrapyResultProcesser
    {
        private HtmlParser _htmlParser;

        public ScrapyResultHtmlProcesser() {
            _htmlParser = new HtmlParser();
        }
        
        public List<ScrapyResult> Process(ScrapyHttpResponse response, ScrapySelector selector)
        {
            var results = new List<ScrapyResult>();

            if (string.IsNullOrEmpty(selector.Query))
            {
                var result = GetScrapyResult(selector.Name, response.Content, selector.ScrapyResultType, selector.Regex);
                results.Add(result);
            }
            else
            {
                var document = _htmlParser.Parse(response.Content);
                var nodes = document.QuerySelectorAll(selector.Query);

                for (int index = 0; index < nodes.Length; index++)
                {
                    var node = nodes[index];
                    results.Add(GetScrapyResult($"{selector.Name}[{index}]", node.OuterHtml, selector.ScrapyResultType, selector.Regex));
                }
            }
            
            return results;
        }

        private ScrapyResult GetScrapyResult(string name, string value, ScrapyResultType type, string regex)
        {
            var result = new ScrapyResult() { Name = name, Type = type };

            if (string.IsNullOrEmpty(regex)) {
                result.Value = value;
            } else {
                var reg = new Regex(regex);
                var matches = reg.Match(value);
                result.Value = matches.Groups[name].Value;
            }

            result.InternalResponse = new ScrapyHttpResponse(result.Value);

            return result;
        }
    }
}
