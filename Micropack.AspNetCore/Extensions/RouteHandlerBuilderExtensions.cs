using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore;

public record class ResponseModel(string Message);

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder Produces404NotFound(this RouteHandlerBuilder builder)
    {
        builder.Produces(404, typeof(ResponseModel));
        return builder;
    }

    public static RouteHandlerBuilder Produces409Conflict(this RouteHandlerBuilder builder)
    {
        builder.Produces(409, typeof(ResponseModel));
        return builder;
    }

    public static RouteHandlerBuilder Produces304NotModified(this RouteHandlerBuilder builder)
    {
        builder.Produces(304, typeof(ResponseModel));
        return builder;
    }

    public static RouteHandlerBuilder Produces400BadRequest(this RouteHandlerBuilder builder)
    {
        builder.Produces(400, typeof(ResponseModel));
        return builder;
    }

    public static RouteHandlerBuilder Produces200OK(this RouteHandlerBuilder builder)
    {
        builder.Produces(200);
        return builder;
    }

    public static RouteHandlerBuilder Produces200OK<TResponse>(this RouteHandlerBuilder builder)
    {
        builder.Produces<TResponse>(200);
        return builder;
    }
}