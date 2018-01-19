using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
//using MejorPrecio.Common;
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
                //var myProduct = myProdutApi.SearchProductByID(new Guid("3273A441-48C3-48D1-8DFF-0005003092A4"));
                var myProduct = myProdutApi.SearchProductByID(uId);
                ViewData["srcImg"] = myProduct.ImgSrc;
                ViewData["nameProduct"] = myProduct.NameProduct;
                ViewData["brand"] = myProduct.Brand;
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                RedirectToAction("products", "index");
            }
            return View("NewPrice");
        }

[HttpGet]
        public IActionResult Map()
        {
            return View("ViewMap");
        }

        public List<Common.Price> ViewMapPrices(Guid idProd)
        {
            var api = new PricesApi();
            var prod = new Common.Product();
            prod.IdProduct = idProd;

            return api.FindBestPrice(prod);
        }

        public string ViewMapUserEmail(Guid idUser)
        {
            var api = new UsersApi();
            var user = new Common.ApplicationUser();
            
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

        public string ViewMapProductData(Guid idProduct)
        {
            var api = new ProductsApi();
            Common.Product prod = api.SearchProductByID(idProduct);
            if(prod == null)
            {
                return " -";
            }
            return prod.Description;
        }

        public IActionResult PriceSucces(RegisterPriceModel priceToLoad)
        {
            try
            {
                var myPriceApi = new PricesApi();
                priceToLoad.IdUser = new Guid("0103E7C2-AB6A-4ED6-9A99-0476C88A7C09");
                priceToLoad.IdProduct = new Guid("3273A441-48C3-48D1-8DFF-0005003092A4");
                var okLoad = myPriceApi.LoadNewPrice(convertMvcToCommon(priceToLoad));
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
                RedirectToAction("products", "index");
            }
            return View("PriceSucces");
        }
        private Common.RegisterPriceModel convertMvcToCommon(RegisterPriceModel prcToConvert)
        {
            var newPriceToConvert = new Common.RegisterPriceModel();
            newPriceToConvert.Date = prcToConvert.Date;
            newPriceToConvert.IdProduct = prcToConvert.IdProduct;
            newPriceToConvert.IdUser = prcToConvert.IdUser;
            newPriceToConvert.Latitude = prcToConvert.Latitude;
            newPriceToConvert.Longitude = prcToConvert.Longitude;
            newPriceToConvert.PriceEffective = prcToConvert.PriceEffective;
            return newPriceToConvert;
        }

    }
}