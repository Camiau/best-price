using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MejorPrecio.Api;
using MejorPrecio.Common;
using MejorPrecio.MvcView.Models;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace MejorPrecio.MvcView.Controllers
{

    public class ProductsController : Controller
    {
        //Sirve para acceder a la carpeta wwwroot
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        private ProductsApi logic = new ProductsApi();

        [HttpGet]
        public IActionResult Index()
        {
                if(TempData["Errors"] != null)
                {
                   ViewBag.Errors = TempData["Errors"].ToString(); 
                }
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
                return View();
            }
            product.ImgSrc = Environment.GetEnvironmentVariable("DefaultPath") + "Products/"+ product.ImgSrc;

            return View(product);
        }

        [HttpPost]
        public IActionResult Search(IFormFile image)
        {

            if(image == null)
            {
                TempData["Errors"] = "Debes ingresar una imagen para buscar";
                return RedirectToAction("Index");
            }
            var code = logic.GetBarcode(image.OpenReadStream());

            return RedirectToAction("Search", new { barCode = code });
        }

        [HttpGet]
        public IActionResult NewProduct(string barCode)
        {
            if (String.IsNullOrEmpty(barCode))
            {
                return View();
            }
            else
            {
                ViewBag.barCode = barCode;
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> NewProduct(ProductRegisterViewModel model, IFormFile barCodeImage, IFormFile productImage, Models.RegisterPriceModel newPrice)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var productsImagesFolder = Path.Combine(Directory.GetCurrentDirectory() , "img", "Products");

            var newProduct = new ProductRegister()
            {
                Description = model.Description,
                Brand = model.Brand,
                //NameProduct = model.ProductName,
            };

            //Si no nos envía el barCode como string debemos procesar el archivo
            if (String.IsNullOrEmpty(model.BarCode))
            {

                newProduct.BarCode = logic.GetBarcode(barCodeImage.OpenReadStream());

                /*En estas líneas buscamos la extension del archivo  */
                string removeString = @"image/";
                int index = productImage.ContentType.IndexOf(removeString);
                string cleanExt = (index < 0)
                    ? productImage.ContentType
                    : productImage.ContentType.Remove(index, removeString.Length);

                if (cleanExt == @"jpeg")
                {
                    cleanExt = "jpg";
                }

                /*Procesamos el nombre del archivo para ya guardarlo */
                newProduct.ImgSrc = newProduct.BarCode + "." + cleanExt;

            }
            else
            {
                newProduct.BarCode = model.BarCode;
                string removeString = @"image/";
                int index = productImage.ContentType.IndexOf(removeString);
                string cleanExt = (index < 0)
                    ? productImage.ContentType
                    : productImage.ContentType.Remove(index, removeString.Length);

                if (cleanExt == @"jpeg")
                {
                    cleanExt = "jpg";
                }

                /*Procesamos el nombre del archivo para ya guardarlo */
                newProduct.ImgSrc = newProduct.BarCode + "." + cleanExt;
            }

            //Guardamos la fecha actual para el nuevo precio
            newPrice.Date = DateTimeOffset.Now;
            /*Si no salta ninguna excepcion el producto no existía y se crea.
            Tengo que guardar en la BDD el producto antes de guardar la imagen en disco, en caso de que salga algo mal que explote ahora y no una vez que guardamos la imagen...*/
            try
            {
                newPrice.IdProduct = logic.Register(newProduct);
            }

            //Caso contrario el producto existía o ocurrió un error no manejado
            catch (Exception e)
            {
                //ViewBag.Message = e.Message;
                ModelState.AddModelError(String.Empty, e.Message);
                return View();
            }

            //Le decimos el path donde guardar el archivo
            productsImagesFolder = Path.Combine(productsImagesFolder, newProduct.ImgSrc);
            using (var fileStream = new FileStream(productsImagesFolder, FileMode.Create))
            {
                await productImage.CopyToAsync(fileStream);
            }

            return RedirectToAction("PriceSucces", "Price", newPrice);
        }
    }
}