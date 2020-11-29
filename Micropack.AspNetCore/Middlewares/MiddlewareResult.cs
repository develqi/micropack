using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore.Middlewares
{
    public class MiddlewareResult
    {
        public static async Task Ok(HttpContext context, object data)
        {
            var response = new { data };

            await ReturnResponse(context, 200, response);
        }

        public static async Task ReturnNotFound(HttpContext context, string message)
        {
            var response = new { message };

            await ReturnResponse(context, 404, response);
        }

        public static async Task ReturnBadRequest(HttpContext context, string message)
        {
            var response = new { error = message };

            await ReturnResponse(context, 400, response);
        }

        public static async Task ReturnNotFound(HttpContext context, Exception exception)
        {
            await ReturnResponse(context, StatusCodes.Status404NotFound, null);
        }

        public static async Task ReturnNoChangesDetected(HttpContext context, Exception exception)
        {
            await ReturnResponse(context, StatusCodes.Status304NotModified, null);
        }

        public static async Task CascadeDelete(HttpContext context, Exception exception)
        {
            await ReturnResponse(context, StatusCodes.Status409Conflict, exception.Message);
        }

        public static async Task RetrunInternalServerError(HttpContext context, Exception exception)
        {
            var response = new { error = "Internal Server Error" };

            await ReturnResponse(context, 500, response);
        }

        public static async Task ReturnResponse(HttpContext context, int statusCode, object response)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var jsonResponse = JsonConvert.SerializeObject(response);

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
