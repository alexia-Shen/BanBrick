using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Http
{
    public class HttpHeader
    {
        public HttpHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public string Value { get; }
    }
}
