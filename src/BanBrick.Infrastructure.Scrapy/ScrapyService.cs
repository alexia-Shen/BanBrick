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
            var result = processer.Process(GetUberEatsScapyConfiguration(), searchParameters);

            //var result = processer.Process(GetMenulogScrapyConfiguration(), searchParameters);
        }

        private ScrapyConfiguration GetMenulogScrapyConfiguration() {
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
                            ScrapyResultType = ScrapyResultType.Object,
                            SelectorSourceType = SelectorSourceType.Html,
                            Query = ".listing-item",
                            SubSelectors = new List<ScrapySelector>() {
                                new ScrapySelector() {
                                    Name = "TotalRating",
                                    ScrapyResultType = ScrapyResultType.Property,
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

        //RequestUriTemplate = "/rtapi/eats/v2/marketplaces",
        //RequestContentTemplate = "{\"targetLocation\":{\"latitude\":-33.8688197,\"longitude\":151.2092955,\"reference\":\"ChIJP5iLHkCuEmsRwMwyFmh9AQU\",\"type\":\"google_places\",\"address\":{\"title\":\"Sydney\",\"address1\":\"Sydney NSW 2000\",\"city\":\"Sydney\"}},\"hashes\":{\"stores\":\"\"},\"feed\":\"combo\",\"feedTypes\":[\"STORE\",\"SEE_ALL_STORES\"],\"feedVersion\":2}",
        private ScrapyConfiguration GetUberEatsScapyConfiguration() {
            return new ScrapyConfiguration() {
                UseBrowserEmulator = true,
                ScrapyMethods = new List<ScrapyMethod>() {
                    new ScrapyMethod() {
                        HttpMethod = HttpMethod.Get,
                        RequestHost = "https://www.ubereats.com",
                        Selector = new ScrapySelector(){
                            Name = "Headers",
                            ScrapyResultType = ScrapyResultType.Property,
                            SelectorSourceType = SelectorSourceType.Header,
                            AddToParameters = true
                        },
                        NextScrapyMethod = new ScrapyMethod() {
                            HttpMethod = HttpMethod.Post,
                            RequestHost = "https://www.ubereats.com",
                            Selector = new ScrapySelector() {
                                Name = "Restrants",
                                ScrapyResultType = ScrapyResultType.Object,
                                SelectorSourceType = SelectorSourceType.Json
                            }
                        }
                    }
                }
            };
        }
    }
}
