using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.MvcView.Models;
using System.Net.Http;
using MejorPrecio.Api;

namespace MejorPrecio.MvcView.Controllers
{
    public class PriceController : Controller
    {
        public IActionResult Index(Guid uId)
        {
            try
            {
                var myProdutApi = new ProductsApi();
                // var myProduct=myProdutApi.SearchProductByID(new Guid("3273A441-48C3-48D1-8DFF-0005003092A4"));
                var myProduct = myProdutApi.SearchProductByID(uId);
                ViewData["srcImg"] = myProduct.imgSrc;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                RedirectToAction("products","index");
                
            }
            return View("NewPrice");
        }
    }
}