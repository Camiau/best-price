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

namespace MejorPrecio.MvcView.Controllers
{
    public class LogInController : Controller
    {
        public async Task<IActionResult> Index(LogInViewModel model)
        {
            var myUsersApi = new UsersApi();
            if (model.Dni==null||model.Email==null)
            {
                this.ModelState.Clear();
                return View("LogIn");
            }
            int number;
            if (!(Int32.TryParse(model.Dni, out number)))
            {
                this.ModelState.AddModelError("dni", "Dni Incorrecto");
                return View("LogIn");
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
                //svar idClaim= new Claim(ClaimTypes.)
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