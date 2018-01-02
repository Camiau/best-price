using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.Common;
using MejorPrecio.Api;

namespace MejorPrecio.WebApi.Controllers
{
    [Route("api/price")]
    public class PriceController : Controller
    {
        // GET api/findbestprice
        [HttpGet]
        public IEnumerable<Price> Get(int idProd)
        {
            var pricesAPI = new PricesApi();

            var prod = new Product();
            prod.IdProduct = idProd;

            return pricesAPI.FindBestPrice(prod);     
        }

        // GET api/values/5
        /* 
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        } 
        */

        // POST api/loadnewprice
        [HttpPost]
        public IActionResult Post([FromBody]Price price)//COMO ASIGNO EL ID DE PRODUCTO?
        {
            new PricesApi().LoadNewPrice(price);
            
            return this.StatusCode(201);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var priceAPI = new PricesApi();
           // var price = PricesApi.ObtainPrice(id);
            if (price != null)
            {
                priceAPI.DeletePrice(price);
                return this.StatusCode(204);
            }
            else
            {
                return this.StatusCode(404);
            }


        }
    }
}
