namespace Citrus.Models
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static ServiceResponse<T> SuccessResponse(T data, string? message = null)
            => new ServiceResponse<T> { Success = true, Data = data, Message = message };

        public static ServiceResponse<T> FailResponse(string message)
            => new ServiceResponse<T> { Success = false, Message = message };

        public static ServiceResponse<T> NotFound(string? message = null)
            => new ServiceResponse<T> { Success = false, Message = message ?? "Not found." };

        public static ServiceResponse<T> ValidationError(string message)
            => new ServiceResponse<T> { Success = false, Message = message };
    }
}