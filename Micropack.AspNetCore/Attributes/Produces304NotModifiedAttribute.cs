using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore
{
    public class Produces304NotModifiedAttribute : ProducesResponseTypeAttribute
    {
        public Produces304NotModifiedAttribute() : base(StatusCodes.Status304NotModified)
        {

        }
    }
}
