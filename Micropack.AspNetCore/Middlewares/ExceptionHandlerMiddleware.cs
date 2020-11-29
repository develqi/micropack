//using System;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Micropack.Domain.Abstraction;

//namespace Micropack.AspNetCore.Middlewares
//{
//    public class ExceptionHandlerMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public ExceptionHandlerMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }

//        public async Task Invoke(HttpContext context)
//        {
//            try
//            {
//                await _next.Invoke(context);
//            }
//            catch (NotFoundException exception)
//            {
//                await MiddlewareResult.ReturnNotFound(context, exception);
//            }

//            catch (NoChangesDetectedException exception)
//            {
//                await MiddlewareResult.ReturnNoChangesDetected(context, exception);
//            }
//            catch (CascadeDeleteException exception)
//            {
//                await MiddlewareResult.CascadeDelete(context, exception);
//            }
//            catch (Exception exception)
//            {
//                await MiddlewareResult.RetrunInternalServerError(context, exception);
//            }
//        }
//    }
//}
