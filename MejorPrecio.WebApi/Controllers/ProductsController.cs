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
        private ProductsApi negocio = new ProductsApi();

        BarcodeScanner scanner = new BarcodeScanner();

        [HttpGet]
        public IActionResult Get(string search)
        {
            if (search == null)
            {
                return StatusCode(400);
            }

            var product = negocio.SearchByBarCode(search);
            return Json(product);
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

    }
}