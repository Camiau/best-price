using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MejorPrecio.Api;
using MejorPrecio.Common;
using MejorPrecio.MvcView.Models;


namespace MejorPrecio.MvcView.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsApi logic = new ProductsApi();

        [HttpGet]
        public IActionResult Index()
        {
            TempData["BarCode"] = String.Empty;

            return View();
        }

        [HttpGet]
        public IActionResult Search(string barCode)
        {
            if (String.IsNullOrEmpty(barCode))
            {
                ModelState.AddModelError(String.Empty, "Debes ingresar un parámetro de búsqueda.");
                return View();
            }

            var product = logic.SearchByBarCode(barCode);

            if (product == null)
            {
                ViewBag.BarCode = barCode;
                TempData["BarCode"] = barCode;
                return View();
            }

            return View(product);
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
            var barCode = TempData["BarCode"];
            return View(barCode);
        }

        [HttpPost]
        public IActionResult NewProduct(ProductRegisterViewModel model, IFormFile BarCodeImage, string BarCode)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var barCode = TempData["BarCode"];

            return View();
        }

    }
}