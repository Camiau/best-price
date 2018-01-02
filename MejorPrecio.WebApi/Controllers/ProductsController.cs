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
        public IActionResult Get([FromBody]string filePath)
        {

            /*var filePath = Path.GetTempFileName();

            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
            }*/
            string code = scanner.ScanBarcode(filePath);//Cambiar path imagen
            var product = negocio.SearchByCodeBar(code);
            return Json(product);
        }

    }
}