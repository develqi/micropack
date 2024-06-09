using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Micropack.Abstraction;

public record class BusinessExceptionResponse
{
    public string? Message { get; set; }
}

public class BusinessException : Exception
{
    public int HttpStatusCode { get; set; }

    public string ResponseMessage { get; set; }

    public BusinessException(int statusCode)
    {
        HttpStatusCode = statusCode;
    }

    public async Task Handle(HttpContext context)
    {
        context.Response.StatusCode = HttpStatusCode;
        context.Response.ContentType = "application/json";

        var jsonResponse = JsonSerializer.Serialize(new BusinessExceptionResponse { Message = ResponseMessage });

        await context.Response.WriteAsync(jsonResponse);
    }
}

public abstract class BusinessException<TResponse> : Exception where TResponse : BusinessExceptionResponse, new()
{
    public int HttpStatusCode { get; set; }

    public string? ResponseMessage { get; set; }

    public virtual TResponse GetResponse() => new() { Message = ResponseMessage };

    public async Task Handle(HttpContext context)
    {
        context.Response.StatusCode = HttpStatusCode;
        context.Response.ContentType = "application/json";

        var jsonResponse = JsonSerializer.Serialize(GetResponse());

        await context.Response.WriteAsync(jsonResponse);
    }
}