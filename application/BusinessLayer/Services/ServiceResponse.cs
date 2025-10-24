using Application.BusinessLayer.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.BusinessLayer.Services
{
    public class ServiceResponse<T>
    {
        public T Dto { get; }
        public string ErrorMessage { get; }
        public ServiceError DetailedError { get; } // used for debugging exceptions

        public bool Success;

        public ServiceResponse(T entity)
        {
            Dto = entity;
            ErrorMessage = null;
            Success = true;
        }

        public ServiceResponse(string errorMessage)
        {
            Dto = default;
            ErrorMessage = errorMessage;
            Success = false;
        }

        public ServiceResponse(ServiceError error)
        {
            Dto = default;
            DetailedError = error;
            Success = false;
        }
    }
}

