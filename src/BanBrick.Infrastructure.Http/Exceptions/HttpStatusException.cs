using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BanBrick.Infrastructure.Http.Exceptions
{
    public class HttpStatusException : Exception
    {
        public HttpStatusException()
        {
        }

        public HttpStatusException(string message) : base(message)
        {
        }

        public HttpStatusException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
