using BanBrick.Infrastructure.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.HttpProcess
{
    public interface IScrapyTemplateProcessor
    {
        HttpContent GetContentBody(string template, IDictionary<string, string> parameters);

        List<HttpHeader> GetHttpHeaders(string template, IDictionary<string, string> parameters);

        string ProcessTemplate(string template, IDictionary<string, string> parameters);
    }
}
