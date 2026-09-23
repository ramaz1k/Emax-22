using System.Net;

namespace Domain.ApieResponse;

using System.Net;

public class Response<T>
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public T? Data { get; set; }

    // Универсальный конструктор с числовым StatusCode
    public Response(int statusCode, string message, T? data = default)
    {
        StatusCode = statusCode;
        Message = message;
        Data = data;
    }

    // Дополнительный удобный конструктор с HttpStatusCode (переводит enum в int)
    public Response(HttpStatusCode statusCode, string message, T? data = default)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Data = data;
    }
}