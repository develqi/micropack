using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Micropack.DesignPattern.Samples.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var purchase = new Purchase
            {
                PurchaseAmount = 120,
                Setting = new Setting { RoundingMethod = RoundingMethods.RoundToDown },
                Customer = new Customer { LoyaltyLevel = LoyaltyLevels.Gold, Point = 0 }
            };

            purchase.UpdateCustomerPoints();

            return new string[] { "value1", "value2" };
        }
    }
}
