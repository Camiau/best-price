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
        public IActionResult Index()
        {
            var myProdutApi= new ProductsApi();
            var myProduct=myProdutApi.SearchProductByID(new Guid("3273A441-48C3-48D1-8DFF-0005003092A4"));
            //ViewData["srcImg"] = "http://static5.businessinsider.com/image/5810c453b28a642b0f8b45a6-2048/14500665_588909221311230_4264909815589193857_o.jpg";
            ViewData["srcImg"] = myProduct.imgSrc;
            
            return View("NewPrice");
        }
    }
}