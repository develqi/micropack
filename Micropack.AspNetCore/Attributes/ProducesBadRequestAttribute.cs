using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore
{
    public class ProducesBadRequestAttribute : ProducesResponseTypeAttribute
    {
        public ProducesBadRequestAttribute() : base(StatusCodes.Status400BadRequest)
        {

        }
    }
}
