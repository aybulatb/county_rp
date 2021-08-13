namespace CountyRP.ApiGateways.AdminPanel.Infrastructure.Exceptions
{
    public class ServiceException<T> : ServiceException
    {
        public T Response { get; }

        public ServiceException(
            string message,
            int statusCode,
            T result
        )
            : base(message, statusCode)
        {
            Response = result;
        }
    }
}
