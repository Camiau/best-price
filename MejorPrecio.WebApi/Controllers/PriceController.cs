using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.Common;
using MejorPrecio.Api;

namespace MejorPrecio.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class PriceController : Controller
    {
        // GET api/findbestprice
        [HttpGet]
        public IEnumerable<Price> Get(int idProd)
        {
            var pricesAPI = new PricesApi();

            var prod = new Product();
            prod.Id = idProd;

            return pricesAPI.FindBestPrice(prod);     
        }

        // POST api/loadnewprice
        [HttpPost]
        public IActionResult Post([FromBody]Price price)
        {
            new PricesApi().LoadNewPrice(price);
            return this.StatusCode(201);
        }

        // DELETE api/values/5
        [HttpDelete] //[HttpDelete("price")]
        public IActionResult Delete([FromBody]Price price)
        {
            var priceAPI = new PricesApi();
            var priceToDelete = priceAPI.ObtainPrice(price);
            if (priceToDelete != null)
            {
                priceAPI.DeletePrice(priceToDelete);
                return this.StatusCode(204);
            }
            else
            {
                return this.StatusCode(404);
            }

        }
       
    }
}
