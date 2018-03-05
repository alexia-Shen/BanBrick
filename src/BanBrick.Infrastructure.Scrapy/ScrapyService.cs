using AngleSharp.Dom.Html;
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

namespace BanBrick.Infrastructure.Scrapy
{
    public class ScrapyService
    {
        public void Test() {
            var searchParameters = new Dictionary<string, string>();
            searchParameters.Add("Suburb", "burwood");
            searchParameters.Add("PostCode", "2134");

            var processer = new ScrapyProcessor();

            var result = processer.Process(GetMenulogScrapingConfiguration(), searchParameters);
        }

        private ScrapyConfiguration GetMenulogScrapingConfiguration() {
            return new ScrapyConfiguration()
            {
                UseBrowserEmulator = true,
                ScrapyMethods = new List<ScrapyMethod>() {
                    new ScrapyMethod() {
                        HttpMethod = HttpMethod.Get,
                        RequestHost = "https://www.menulog.com.au",
                        RequestUriTemplate = "/area/{{PostCode}}-{{Suburb}}/",
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
