using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.Api;
using System.Net.Http;
using MejorPrecio.Common;



namespace MejorPrecio.MvcView.Controllers
{
    public class PriceController : Controller
    {
         
        public IActionResult Index()
        {
            ViewData["Message"] = "Your application description page.";

            return View("NewPrice");
        }

[HttpGet]
        public IActionResult Map()
        {
            /* var api = new PricesApi();
            var prod = new Product();
            prod.IdProduct = idProd;

            ViewBag.PriceList = api.FindBestPrice(prod); */
            return View("ViewMap");
        }

        public List<Price> ViewPrices(Guid idProd)
        {
            var api = new PricesApi();
            var prod = new Product();
            prod.IdProduct = idProd;

            return api.FindBestPrice(prod);
        }


    }
}