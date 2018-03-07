using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Scrapy.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.HttpProcess
{
    public class ScrapyHttpProcessor: IScrapyHttpProcessor
    {
        private BanBrickHttpClient _httpClient;
        private IScrapyTemplateProcessor _templateProcessor;

        public ScrapyHttpProcessor(IScrapyTemplateProcessor templateProcessor)
        {
            _httpClient = new BanBrickHttpClient(true);
            _templateProcessor = templateProcessor;
        }

        public string Host {
            get => _httpClient.BaseAddress;
            set { _httpClient.BaseAddress = value; }
        }

        public ScrapyResponse Process(ScrapyMethod scrapyMethod, IDictionary<string, string> paramters, IEnumerable<HttpHeader> defualtHeaders)
        {
            var requstUri = _templateProcessor.ProcessTemplate(scrapyMethod.RequestUriTemplate, paramters);
            var requestContent = _templateProcessor.GetContentBody(scrapyMethod.RequestContentTemplate, paramters);
            var requestHeaders = _templateProcessor.GetHttpHeaders(scrapyMethod.RequestHeaderTemplate, paramters);
            
            if (defualtHeaders != null)
            {
                var addtionalRequestHeaders = defualtHeaders.Where(x => !requestHeaders.Any(y => y.Name == x.Name)).ToList();
                requestHeaders.AddRange(addtionalRequestHeaders);
            }

            if (!string.IsNullOrEmpty(scrapyMethod.RequestHost))
            {
                _httpClient.BaseAddress = scrapyMethod.RequestHost;
            }

            var httpResponse = _httpClient.Send(scrapyMethod.HttpMethod, requstUri, requestHeaders.ToArray(), requestContent);
            var response = new ScrapyResponse(httpResponse);

            return response;
        }
        
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
