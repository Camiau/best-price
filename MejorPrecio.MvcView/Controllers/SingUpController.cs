using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Threading;
using Microsoft.AspNetCore.Authentication.Cookies;
using MejorPrecio.MvcView.Models;
using MejorPrecio.Api;
using MejorPrecio.Common;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MejorPrecio.MvcView.Controllers
{
    public class SingUpController : Controller
    {
        public async Task<IActionResult> Index(SigUpViewModel model,IFormFile imgDni)
        {
            var myUsersApi = new UsersApi();
            if (model.Dni == null || model.Email == null || model.Name == null || model.Surname == null)
            {
                this.ModelState.Clear();
                ViewBag.imgSrc = Environment.GetEnvironmentVariable("DefaultPath") + "Untitled.png";
                return View("SingUp");
            }
            int number;
            if (!(Int32.TryParse(model.Dni, out number)))
            {
                this.ModelState.AddModelError("dni", "Dni Incorrecto");
                return View("SingUp");
            }
            // To upload the image from DNI user 
            using (var fileStream = new FileStream("../img/sjsjs.png", FileMode.Create))
            {
                await imgDni.CopyToAsync(fileStream);
            }
            var usrToLogIn = new SimpleUserModel(model.Email, model.Dni);
            if (myUsersApi.Login(usrToLogIn) == UsersApi.SignInStatus.RequiresVerification)
            {
                this.ModelState.AddModelError("LogIn", "Se requiere verificacion del Email");
            }
            else if (myUsersApi.Login(usrToLogIn) == UsersApi.SignInStatus.Failure)
            {
                this.ModelState.AddModelError("email", "Dni o email incorrecto");
            }
            if (ModelState.IsValid)
            {
                var dniClaim = new Claim(ClaimTypes.Name, model.Dni);
                var mailClaim = new Claim(ClaimTypes.Email, model.Email);
                var roleClaim = new Claim(ClaimTypes.Role, myUsersApi.GetCurrentRole().RoleName);
                var identity = new ClaimsIdentity(new[] { dniClaim, mailClaim, roleClaim }, "cookie");
                var principal = new ClaimsPrincipal(identity);

                await this.HttpContext.SignInAsync(principal);
                // hacer login

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("LogIn");
            }
        }
    }
}