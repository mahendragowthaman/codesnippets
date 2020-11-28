using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.Services;

namespace TodoApp
{
    public enum Status
    {
        Succeed,
        Error
    }

    public class ServiceResponse<T>
    {
        public static ServiceResponse<T> CreateSuccessResponse(T _responseObject)
        {
            return new ServiceResponse<T>()
            {
                Status = Status.Succeed,
                ResponseObject = _responseObject
            };
        }

        public static ServiceResponse<T> CreateErrorResponse(T _responseObject, Exception exception)
        {
            return new ServiceResponse<T>()
            {
                Status = Status.Error,
                ResponseObject = _responseObject,
                CorrelationId = ServiceHelper.GenerateCorrelationId(),
                Message = exception?.Message,
                StackTrace = exception.StackTrace
            };
        }

        public Status Status { get; set; }
        public T ResponseObject { get; set; }
        public string CorrelationId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}

