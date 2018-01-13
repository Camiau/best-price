using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MejorPrecio.MvcView.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;

namespace MejorPrecio.MvcView.Controllers
{
    public class ProductsController : Controller
    {

        [HttpGet]
        public IActionResult Search()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Search(IFormFile image)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            clientHandler.AllowAutoRedirect = false;

            using (HttpClient client = new HttpClient(clientHandler))
            {

                client.BaseAddress = new Uri("http://localhost:5003/");
                MultipartFormDataContent form = new MultipartFormDataContent();

                try
                {
                    using (var ms = new MemoryStream())
                    {
                        image.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string s = Convert.ToBase64String(fileBytes);
                        HttpContent content = new StringContent(s);
                        form.Add(content, "file");
                    }
                    
                    var response = client.PostAsync("api/Products", form).Result;

                    return View();
                }
                catch (Exception)
                {
                    return StatusCode(501); // 500 is generic server error
                }
            }

            /*using (MemoryStream m = new MemoryStream())
            {
                file.CopyTo(m);
                byte[] imageBytes = m.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
            }

            return StatusCode(200);*/
        }


        public IActionResult NewProduct()
        {

            return View();
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
    }
}