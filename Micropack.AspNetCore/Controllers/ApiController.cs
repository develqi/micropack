using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Micropack.AspNetCore
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        //public class PaginationResult<TResponse> : IActionResult where TResponse : class, new()
        //{
        //    private readonly PaginationResponse<TResponse> _response;

        //    public PaginationResult(PaginationResponse<TResponse> response)
        //    {
        //        _response = response;
        //    }

        //    public async Task ExecuteResultAsync(ActionContext context)
        //    {
        //        var result = new ObjectResult(_response);

        //        await result.ExecuteResultAsync(context);
        //    }
        //}

        [NonAction]
        public TService GetService<TService>() where TService : class 
            => HttpContext.RequestServices.GetRequiredService<TService>();

        //[NonAction]
        //public IActionResult Pagination<TResponse>(PaginationResponse<TResponse> response) where TResponse : class, new() 
        //    => Ok(new PaginationResult<TResponse>(response));
    }
}
