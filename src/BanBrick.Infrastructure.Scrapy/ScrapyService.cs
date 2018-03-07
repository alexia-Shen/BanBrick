using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Scraping.Enums;
using BanBrick.Infrastructure.Scrapy.HttpProcess;
using BanBrick.Infrastructure.Scrapy.Models;
using BanBrick.Infrastructure.Scrapy.ResultProcess;
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
        public void Test()
        {
            var searchParameters = new Dictionary<string, string>();
            searchParameters.Add("Suburb", "burwood");
            searchParameters.Add("PostCode", "2134");

            var templateProcessor = new ScrapyTemplateProcessor();
            var resultProcessor = new ScrapyResultProcessor();
            using (var httpProcessor = new ScrapyHttpProcessor(templateProcessor))
            {
                var processor = new ScrapyProcessor(httpProcessor, resultProcessor);
                var results = processor.Process(GetMenulogScrapyConfiguration(), searchParameters, GetEmulateHeaders());
            }
        }

        private ScrapyConfiguration GetMenulogScrapyConfiguration()
        {
            return new ScrapyConfiguration()
            {
                Host = "https://www.menulog.com.au",
                ScrapyMethods = new List<ScrapyMethod>() {
                    new ScrapyMethod() {
                        HttpMethod = HttpMethod.Get,
                        RequestUriTemplate = "/area/{{PostCode}}-{{Suburb}}/",
                        Name = "GetResturants",
                        Selectors = new List<ScrapySelector>() {
                            new ScrapySelector() {
                                Name = "Resturants",
                                SourceType = ScrapySourceType.Html,
                                ResultType = ScrapyResultType.Object,
                                Query = ".listing-item",
                                SubSelectors = new List<ScrapySelector>() {
                                    new ScrapySelector() {
                                        Name = "TotalRating",
                                        DefaultValue = "0",
                                        IsParameter = true,
                                        IsSingle = true,
                                        SourceType = ScrapySourceType.Html,
                                        ResultType = ScrapyResultType.Property,
                                        Query = "meta[itemprop=ratingValue]",
                                        Regex = "content=\"(?'TotalRating'.*)\""
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }

        //RequestUriTemplate = "/rtapi/eats/v2/marketplaces",
        //RequestContentTemplate = "{\"targetLocation\":{\"latitude\":-33.8688197,\"longitude\":151.2092955,\"reference\":\"ChIJP5iLHkCuEmsRwMwyFmh9AQU\",\"type\":\"google_places\",\"address\":{\"title\":\"Sydney\",\"address1\":\"Sydney NSW 2000\",\"city\":\"Sydney\"}},\"hashes\":{\"stores\":\"\"},\"feed\":\"combo\",\"feedTypes\":[\"STORE\",\"SEE_ALL_STORES\"],\"feedVersion\":2}",
        private ScrapyConfiguration GetUberEatsScapyConfiguration()
        {
            return new ScrapyConfiguration()
            {
                Host = "https://www.ubereats.com",
                ScrapyMethods = new List<ScrapyMethod>() {
                    new ScrapyMethod() {
                        HttpMethod = HttpMethod.Get,
                        Selectors = new List<ScrapySelector>() {
                            new ScrapySelector() {
                                Name = "Headers",
                                SourceType = ScrapySourceType.Header,
                                ResultType = ScrapyResultType.Property,
                                IsParameter = true
                            }
                        },
                        NextMethod = new ScrapyMethod() {
                            HttpMethod = HttpMethod.Post,
                            RequestUriTemplate = "/rtapi/eats/v1/allstores?plugin=StorefrontFeedPlugin",
                            RequestHeaderTemplate = "{\"Host\":\"www.ubereats.com\", \"Origin\":\"https://www.ubereats.com\", \"Referer\":\"https://www.ubereats.com/stores/\", \"x-csrf-token\": \"{{Headers.x-csrf-token}}\"}",
                            RequestContentTemplate = "{\"pageInfo\":{\"offset\":0,\"pageSize\":80},\"targetLocation\":{\"latitude\":-33.8688197,\"longitude\":151.2092955,\"reference\":\"ChIJP5iLHkCuEmsRwMwyFmh9AQU\",\"type\":\"google_places\",\"address\":{\"title\":\"Sydney\",\"address1\":\"Sydney NSW 2000\",\"city\":\"Sydney\"}}}",
                            Selectors = new List<ScrapySelector>() {
                                new ScrapySelector() {
                                    Name = "Restrants",
                                    SourceType = ScrapySourceType.Json,
                                    ResultType = ScrapyResultType.Object
                                }
                            }
                        }
                    }
                }
            };
        }
        
        private HttpHeader[] GetEmulateHeaders()
        {
            var connection = new HttpHeader("Connection", "keep-alive");
            var userAgent = new HttpHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.112 Safari/537.36");
            var accept = new HttpHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            var acceptEncoding = new HttpHeader("Accept-Encoding", "gzip, deflate");
            var acceptLanguage = new HttpHeader("Accept-Language", "en-GB,en;q=0.9,en-US;q=0.8,zh-CN;q=0.7,zh;q=0.6,zh-TW;q=0.5");

            return new HttpHeader[] { connection, userAgent, accept, acceptEncoding, acceptLanguage };
        }
    }
}
