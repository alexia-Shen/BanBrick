using AngleSharp.Dom.Html;
using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Http.Extensions;
using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Services.Scraping.Enums;
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
                Host = "https://www.ubereats.com",
                ScrapyMethods = new List<ScrapyMethod>() {
                    new ScrapyMethod() {
                        HttpMethod = HttpMethod.Get,
                        Selector = new ScrapySelector(){
                            Name = "Headers",
                            ScrapyResultType = ScrapyResultType.Property,
                            SelectorSourceType = SelectorSourceType.Header,
                            AddToParameters = true
                        },
                        NextScrapyMethod = new ScrapyMethod() {
                            HttpMethod = HttpMethod.Post,
                            RequestUriTemplate = "/rtapi/eats/v1/allstores?plugin=StorefrontFeedPlugin",
                            RequestHeaderTemplate = "{\"Host\":\"www.ubereats.com\", \"Origin\":\"https://www.ubereats.com\", \"Referer\":\"https://www.ubereats.com/stores/\", \"x-csrf-token\": \"{{Headers.x-csrf-token}}\"}",
                            RequestContentTemplate = "{\"pageInfo\":{\"offset\":0,\"pageSize\":80},\"targetLocation\":{\"latitude\":-33.8688197,\"longitude\":151.2092955,\"reference\":\"ChIJP5iLHkCuEmsRwMwyFmh9AQU\",\"type\":\"google_places\",\"address\":{\"title\":\"Sydney\",\"address1\":\"Sydney NSW 2000\",\"city\":\"Sydney\"}},\"sortAndFilters\":[{\"uuid\":\"1c7cf7ef-730f-431f-9072-26bc39f7c021\",\"options\":[{\"uuid\":\"3c7cf7ef-730f-431f-9072-26bc39f7c022\"}]}]}",
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
