using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using AngleSharp.Parser.Html;
using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Scraping.Enums;
using BanBrick.Infrastructure.Scrapy.Models;

namespace BanBrick.Infrastructure.Scrapy.SourceProcess
{
    public class ScrapyHtmlSourceProcessor : IScrapySourceProcessor
    {
        private HtmlParser _htmlParser;

        public ScrapyHtmlSourceProcessor() {
            _htmlParser = new HtmlParser();
        }
        
        public List<ScrapyResult> Process(ScrapyResponse response, ScrapySelector selector)
        {
            var results = new List<ScrapyResult>();

            if (selector.IsSingle == true)
            {
                var value = response.BodyContent;

                if (!string.IsNullOrEmpty(selector.Query))
                {
                    var nodes = _htmlParser.Parse(response.BodyContent).QuerySelectorAll(selector.Query);
                    value = nodes.Length > 0 ? nodes[0].OuterHtml : "";
                }

                var result = GetScrapyResult(selector.Name, response.BodyContent, response.HttpHeaders, selector);
                results.Add(result);
            }
            else
            {
                var nodes = _htmlParser.Parse(response.BodyContent).QuerySelectorAll(selector.Query);

                for (int index = 0; index < nodes.Length; index++)
                {
                    var node = nodes[index];
                    results.Add(GetScrapyResult($"{selector.Name}[{index}]", node.OuterHtml, response.HttpHeaders, selector));
                }
            }

            return results;
        }

        private ScrapyResult GetScrapyResult(string name, string content, List<HttpHeader> headers , ScrapySelector selector)
        {
            var result = new ScrapyResult() { Name = name, ResultType = selector.ResultType };

            if (string.IsNullOrEmpty(selector.Regex)) {
                result.Value = content;
            } else {
                var reg = new Regex(selector.Regex);
                var matches = reg.Match(content);
                result.Value = matches.Groups[selector.Name].Value;
            }

            result.ProcessedResponse = new ScrapyResponse(result.Value, headers);

            return result;
        }
    }
}
