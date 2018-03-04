using AngleSharp.Dom.Html;
using BanBrick.Infrastructure.Http;
using BanBrick.Infrastructure.Http.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BanBrick.Services.Scraping
{
    public class ScrapingService
    {
        public void Test() {
            IHtmlDocument html;

            using (var client = new BanBrickHttpClient("https://www.menulog.com.au", true))
            {
                html = client.GetHtml("/area/2134-burwood/", GetEmulateHeaders());
            }
            
            var nodes = html.QuerySelectorAll(".listing-item");
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
    }
}
