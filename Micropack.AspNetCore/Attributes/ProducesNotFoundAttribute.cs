using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore
{
    public class ProducesNotFoundAttribute : ProducesResponseTypeAttribute
    {
        public ProducesNotFoundAttribute() : base(StatusCodes.Status404NotFound)
        {

        }
    }
}
