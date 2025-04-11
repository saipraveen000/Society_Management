namespace Society.Services.NotificationAPI.ExceptionHandling
{
    public class ApiException : Exception
    {
        public ApiException(string message) : base(message) { }
    }
}
