using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.MvcView.Models;
using System.Net.Http;

namespace MejorPrecio.MvcView.Controllers
{
    public class PriceController : Controller
    {
        public IActionResult Index()
        {
            
            return View("NewPrice");
        }
    }
}