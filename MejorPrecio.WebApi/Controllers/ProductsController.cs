using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MejorPrecio.Common;
using MejorPrecio.Api;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace MejorPrecio.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private ProductsApi logic = new ProductsApi();

        private BarcodeScanner scanner = new BarcodeScanner();

        [HttpGet("/{search}")]
        public IActionResult Get(string search)
        {
            if (search == null)
            {
                return StatusCode(400);
            }

            var product = logic.SearchByBarCode(search);

            if(product == null)
            {
                return StatusCode(404);
            }
            else return Json(product);
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                BarcodeScanner scanner = new BarcodeScanner();
                var code = scanner.ScanBarcode(stream);

                return this.RedirectToAction(nameof(Get), new {search = code});
            }
        }

        [HttpPost("register")]
        public IActionResult Register(ProductRegister newProduct)
        {
            try
            {
                var product = logic.Register(newProduct);

                return Json(product);

            }
            catch
            {
                return StatusCode(409);
            }

        }
        [HttpDelete]
        public IActionResult Delete(string barCode)
        {
            try
            {
                logic.Delete(barCode);
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(404);
            }
        }


    }
}