using System;

namespace CountyRP.Forum.Domain.Exceptions
{
    public class ForumException : Exception
    {
        public int StatusCode { get; set; }
        public ForumException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
