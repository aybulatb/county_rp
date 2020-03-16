using System;

namespace CountyRP.WebSite.Exceptions
{
    public class AdapterException : Exception
    {
        public int StatusCode { get; set; }

        public AdapterException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
