using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micropack.AspNetCore;

public record class UnauthorizeModel(string Message);

public class ProducesUnauthorized : ProducesResponseTypeAttribute
{
    public ProducesUnauthorized() : base(StatusCodes.Status401Unauthorized)
    {
        Type = typeof(UnauthorizeModel);
    }
}