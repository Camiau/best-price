using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class UsersApi
    {
        private UserManager userManager = new UserManager();
        public string RegisterUser(RegisterModel newUser)
        {
            var result = userManager.CreateUser(newUser);
            switch (result)
            {
                case UserManager.SignUpStatus.Success:
                    return "Usuario registrado correctamente";
                case UserManager.SignUpStatus.Failure:
                    return "Hubo un error al ingresar los datos. Intente nuevamente";
                default:
                    return "Caíste en el default";
            }
        }

        public string Login(LoginModel userLogin)
        {
            var result = userManager.Login(userLogin);
            switch (result)
            {
                case UserManager.SignInStatus.Success:
                    //Debería crearse la cookie aquí
                    return userManager.logedIn.Email.ToString();
                case UserManager.SignInStatus.Failure:
                    return "Correo electrónico o DNI no existentes";
                case UserManager.SignInStatus.RequiresVerification:
                    return "Necesita verificación del mail";
                default:
                    return "Caíste en el default";
            }

        }

        public string ConfirmEmail(string email, long dni)  
        {
            var result = userManager.ConfirmEmail(email, dni);
            switch (result)
            {
                case true:
                    //Aquí debería crearse la cookie
                    return "Email validado correctamente";
                case false:
                    return "El email ya está validado";
                default: 
                    return "El email no existe";
            }

        }


    }

}