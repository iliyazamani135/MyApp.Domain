namespace MyApp.Application.Common
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static Response<T> SuccessResponse(T data, string? message = null)
        {
            return new Response<T> { Success = true, Data = data, Message = message };
        }

        public static Response<T> FailResponse(string message)
        {
            return new Response<T> { Success = false, Data = default, Message = message };
        }
    }
}
