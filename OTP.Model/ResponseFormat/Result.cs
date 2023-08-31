using System.Diagnostics;
using System.Net;

namespace OTP.Model.ResponseFormat
{
    public class Result<T>
    {
        public string traceId { get; private set; }
        public int statusCode { get; private set; }
        public string? message { get; private set; }
        public T? data { get; private set; }

        public Result(HttpStatusCode StatusCode, string Message, T? Data)
        {
            this.traceId = Activity.Current?.TraceId.ToString();
            this.statusCode = (int)StatusCode;
            this.message = Message;
            this.data = Data;
        }
    }
}