﻿using AngleSharp.Dom.Html;
using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Http.Extensions;
using BanBrick.Services.Scraping.Enums;
using BanBrick.Services.Scraping.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BanBrick.Services.Scraping
{
    public class ScrapyService
    {
        public ScrapyResult Process(ScrapyConfiguration scrapingConfiguration, IDictionary<string, string> paramters)
        {
            var defualtHeaders = new List<HttpHeader>();

            if (scrapingConfiguration.UseBrowserEmulator == true)
                defualtHeaders.AddRange(GetEmulateHeaders());

            var processedReuslts = new List<ScrapyResult>();

            foreach (var scrapyMethod in scrapingConfiguration.ScrapyMethods)
            {
                var processedReuslt = Process(scrapyMethod, defualtHeaders, processedReuslts, paramters);
                processedReuslts.Add(processedReuslt);
            }

            return null;
        }

        public ScrapyResult Process(ScrapyMethod scrapyMethod,  IList<HttpHeader> defualtHeaders,
            IList<ScrapyResult> processedResults, IDictionary<string, string> paramters)
        {
            var autoDecompress = defualtHeaders.Any(x => x.Name.Equals("Accept-Encoding", StringComparison.CurrentCultureIgnoreCase));
            var requstUri = ProcessRequestUriTemplate(scrapyMethod.RequestUriTemplate, paramters);

            using (var httpClient = new BanBrickHttpClient(scrapyMethod.RequestHost, autoDecompress))
            {
                var response = httpClient.Send(scrapyMethod.HttpMethod, requstUri, )
            }
            return null;
        }

        private string ProcessRequestUriTemplate(string template, IDictionary<string, string> parameters)
        {
            return "";
        }

        private HttpContent ProcessRequestContentTemplate(string template, IDictionary<string, string> parameters)
        {
            return null;
        }

        public List<HttpHeader> ProcessRequestHeaderTemplate(string templatre, IDictionary<string, string> parameters)
        {
            var result = new List<HttpHeader>();



            return result;
        }

        public void Test() {
            var searchParameters = new Dictionary<string, string>();
            searchParameters.Add("Suburb", "burwood");
            searchParameters.Add("PostCode", "2134");

            var result = Process(GetMenulogScrapingConfiguration(), searchParameters);
        }

        private HttpHeader[] GetEmulateHeaders()
        {
            var connection = new HttpHeader("Connection", "keep-alive");
            var userAgent = new HttpHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36");
            var accept = new HttpHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            var acceptEncoding = new HttpHeader("Accept-Encoding", "gzip, deflate");
            var acceptLanguage = new HttpHeader("Accept-Language", "en-GB,en;q=0.9,en-US;q=0.8,zh-CN;q=0.7,zh;q=0.6,zh-TW;q=0.5");

            return new HttpHeader[] { connection, userAgent, accept, acceptEncoding, acceptLanguage};
        }

        private ScrapyConfiguration GetMenulogScrapingConfiguration() {
            return new ScrapyConfiguration()
            {
                UseBrowserEmulator = true,
                ScrapyMethods = new List<ScrapyMethod>() {
                    new ScrapyMethod() {
                        HttpMethod = HttpMethod.Get,
                        RequestHost = "https://www.menulog.com.au",
                        RequestUriTemplate = "/area/{PostCode}-{Suburb}/",
                        Selector = new ScrapySelector() {
                            Name = "Resturants",
                            SelectorResultType = SelectorResultType.List,
                            SelectorSourceType = SelectorSourceType.Html,
                            Query = ".listing-item",
                            SubSelectors = new List<ScrapySelector>() {
                                new ScrapySelector() {
                                    Name = "TotalRating",
                                    SelectorResultType = SelectorResultType.Property,
                                    SelectorSourceType = SelectorSourceType.Html,
                                    Query = "meta[itemprop=ratingValue]",
                                    Regex = "content=\"(?'TotalRating'.*)\""
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}