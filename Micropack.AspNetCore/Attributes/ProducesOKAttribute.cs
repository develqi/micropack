using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Micropack.AspNetCore
{
    public class ProducesOKAttribute : ProducesResponseTypeAttribute
    {
        public ProducesOKAttribute() : base(StatusCodes.Status200OK)
        {

        }

        public ProducesOKAttribute(Type type) : base(type, StatusCodes.Status200OK)
        {

        }
    }
}
