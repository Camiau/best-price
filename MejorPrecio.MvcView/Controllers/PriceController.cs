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
            return View("ViewMap");
        }

        public List<Price> ViewPrices(Guid idProd)
        {
            var api = new PricesApi();
            var prod = new Product();
            prod.IdProduct = idProd;

            return api.FindBestPrice(prod);
        }

        public string UserEmail(Guid idUser)
        {
            var api = new UsersApi();
            var user = new ApplicationUser();
            
            user = api.GetUserById( idUser );

            if(user != null)
            {
                return user.Email;
            }
            else
            {
                return " -";
            }
            
        }

        public string ProductData(Guid idProduct)
        {
            var api = new ProductsApi();
            Product prod = api.GetProductById(idProduct);
            
            return prod.description;
        }


    }
}