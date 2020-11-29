using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore
{
    public class Produces409ConflictAttribute : ProducesResponseTypeAttribute
    {
        public Produces409ConflictAttribute() : base(StatusCodes.Status409Conflict)
        {

        }
    }
}
