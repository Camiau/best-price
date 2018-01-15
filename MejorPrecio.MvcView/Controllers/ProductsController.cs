using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.MvcView.Models;
using Microsoft.AspNetCore.Http;
using MejorPrecio.Api;
using MejorPrecio.Common;

namespace MejorPrecio.MvcView.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsApi logic = new ProductsApi();


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Search(IFormFile image)
        {

            var code = logic.GetBarcode(image.OpenReadStream());
            
            return RedirectToAction("Search", new { barCode = code });
        }

        [HttpGet]
        public IActionResult NewProduct()
        {
            var barCode= TempData["BarCode"];     
            return View(barCode);
        }

        [HttpPost]
        public IActionResult NewProduct(ProductRegisterViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(product.description);
        }

        [HttpGet]
        public IActionResult Search(string barCode)
        {
            if(barCode == null || barCode.Length == 0)
            {
                ModelState.AddModelError(String.Empty, "Debes ingresar un parámetro de búsqueda.");
                return View();

            }
            var product = logic.SearchByBarCode(barCode);
            if(product == null)
            {
                TempData["BarCode"] = barCode;
                return RedirectToAction("NewProduct");
            }

            return View(product);
        }
    }
}