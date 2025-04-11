﻿namespace Society.Services.MaintenanceAPI.ExceptionHandling
{
    public class ApiException : Exception
    {
        public int StatusCode { get; }

        public ApiException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
