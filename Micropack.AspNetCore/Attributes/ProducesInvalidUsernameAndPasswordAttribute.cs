using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore;

public class ProducesInvalidUsernameAndPasswordAttribute : ProducesResponseTypeAttribute
{
    public ProducesInvalidUsernameAndPasswordAttribute() : base(StatusCodes.Status422UnprocessableEntity)
    {

    }

    public ProducesInvalidUsernameAndPasswordAttribute(Type type) : base(type, StatusCodes.Status422UnprocessableEntity)
    {
        Type = type;
    }
}
