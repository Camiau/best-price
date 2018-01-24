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
        public async Task<IActionResult> Index(SigUpViewModel model, IFormFile imgDni)
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
            var chkUser = myUsersApi.CheckUser(model.Email, model.Dni);
            if (!(chkUser == UsersApi.UserStatus.OkToContinue))
            {
                if (chkUser == UsersApi.UserStatus.DniExits)
                {
                    this.ModelState.AddModelError("dni", "El dni ya se encuentra registrado");
                }
                if (chkUser == UsersApi.UserStatus.EmailExits)
                {
                    this.ModelState.AddModelError("email", "El email ya se encuentra registrado");
                }
                if (chkUser == UsersApi.UserStatus.UserExist)
                {
                    this.ModelState.AddModelError("dni", "El usuario ya se encuentra registrado");
                }
                return View("SingUp");
            }
            // To upload the image from DNI user 
            var strPath = "../img/" + model.Name + model.Surname +model.Dni + ".png";
            using (var fileStream = new FileStream(strPath, FileMode.Create))
            {
                await imgDni.CopyToAsync(fileStream);
            }
            if (ModelState.IsValid)
            {
                var usrToSignIn = new RegisterModel();
                usrToSignIn.Dni = model.Dni;
                usrToSignIn.Email = model.Email;
                usrToSignIn.ImagePath = strPath;
                usrToSignIn.Name = model.Name;
                usrToSignIn.Surname = model.Surname;
                if (myUsersApi.RegisterUser(usrToSignIn) == UsersApi.SignUpStatus.Success)
                {
                    return RedirectToAction("Index", "LogIn");
                }
                else
                {
                    return View("SingUp");
                }
            }
            else
            {
                return View("SingUp");
            }
        }
    }
}