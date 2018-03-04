using AngleSharp;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Http
{
    public class HtmlDocument
    {
        private IHtmlDocument _document;
        
        public HtmlDocument(string content) {
            _document = new HtmlParser().Parse(content);
        }

        
        public void Test() {
            var document = BrowsingContext.New().OpenAsync("").Result;
        }
    }
}
