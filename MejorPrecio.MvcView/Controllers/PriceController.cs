using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.MvcView.Models;

namespace MejorPrecio.MvcView.Controllers
{
    public class PriceController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Your application description page.";
            ViewData["srcImg"]="https://www.reasonwhy.es/sites/default/files/botellas-coca-cola-reasonwhy.es_.jpg";
            
            return View("NewPrice");
        }
    }
}