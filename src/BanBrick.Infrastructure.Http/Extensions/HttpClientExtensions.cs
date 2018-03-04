using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using BanBrick.Infrastructure.Http.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BanBrick.Infrastructure.Http.Extensions
{
    public static class HttpClientExtensions
    {
        public static Response FormatResponseModel<Response>(this HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new HttpStatusException($"Error {(int)httpResponseMessage.StatusCode}: \nResponse:{httpResponseMessage.Content.ToString()}");

            Response response;

            try
            {
                response = JsonConvert.DeserializeObject<Response>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            }
            catch { throw; }

            return response;
        }

        public static HttpContent FormatJsonContent<T>(this T model)
        {
            return new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        }

        public static async Task<IHtmlDocument> ToHtmlAsync(this HttpResponseMessage httpResponseMessage)
        {
            if (!httpResponseMessage.IsSuccessStatusCode)
                throw new HttpStatusException($"Error {(int)httpResponseMessage.StatusCode}: \nResponse:{httpResponseMessage.Content.ToString()}");

            var source = await httpResponseMessage.Content.ReadAsStringAsync();
            var htmlDocument = await new HtmlParser().ParseAsync(source);

            return htmlDocument;
        }

        public static IHtmlDocument ToHtml(this HttpResponseMessage httpResponseMessage)
        {
            return httpResponseMessage.ToHtmlAsync().Result;
        }
    }
}
