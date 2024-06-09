using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore.MinimalAPIs;

public static class ProducesExtensions
{
    public static RouteHandlerBuilder ProducesGetView<TView>(this RouteHandlerBuilder builder, string summary) where TView : class
    {
        builder.Produces404NotFound()
               .Produces200OK<TView>()
               .WithSummary(summary);

        return builder;
    }

    public static RouteHandlerBuilder ProducesPagination<TPagination>(this RouteHandlerBuilder builder) where TPagination : class
    {
        builder.Produces404NotFound()
               .Produces200OK<TPagination>()
               .WithSummary("Get pagination items");

        return builder;
    }
    public static RouteHandlerBuilder ProducesCreate<TResponse>(this RouteHandlerBuilder builder) where TResponse : class
    {
        builder.Produces409Conflict()
               .Produces400BadRequest()
               .Produces200OK<TResponse>()
               .WithSummary("Create");

        return builder;
    }

    public static RouteHandlerBuilder ProducesUpdate<TResponse>(this RouteHandlerBuilder builder) where TResponse : class
    {
        builder.Produces409Conflict()
               .Produces400BadRequest()
               .Produces304NotModified()
               .Produces200OK<TResponse>()
               .WithSummary("Update");

        return builder;
    }

    public static RouteHandlerBuilder ProducesDelete(this RouteHandlerBuilder builder)
    {
        builder.Produces200OK()
               .Produces409Conflict()
               .Produces404NotFound()
               .Produces400BadRequest()
               .WithSummary("Delete");

        return builder;
    }

    public static RouteHandlerBuilder ProducesExceptionResponse<TResponse>(this RouteHandlerBuilder builder, int statusCode) where TResponse: class, new()
    {
        builder.Produces(statusCode, typeof(TResponse));
        return builder;
    }
}
