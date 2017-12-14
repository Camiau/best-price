using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class UsersApi
    {
        public async Task<string> RegisterUser(RegisterModel newUser)
        {
            var result = await UserManager.CreateUserAsync(newUser);
            switch (result)
            {
                case SignUpStatus.Success:
                    return "Usuario registrado correctamente";
                case SignUpStatus.Failure:
                    return "Hubo un error al ingresar los datos. Intente nuevamente";
                default:
                    return "Caíste en el default";
            }
        }

        public async Task<string> Login(LoginModel userLogin)
        {
            var result = await UserManager.Login(userLogin);
            switch (result)
            {
                case SignInStatus.Success:
                    return "Usuario registrado correctamente";
                case SignInStatus.Failure:
                    return "Hubo un error al ingresar los datos. Intente nuevamente";
                case SignInStatus.RequiresVerification:
                    return "Necesita verificación del mail";
                default:
                    return "Caíste en el default";
            }

        }

        public async Task<string> ConfirmEmail(LoginModel userLogin)
        {
            var result = await UserManager.Login(userLogin);
            switch (result)
            {
                case SignInStatus.Success:
                    return "Usuario registrado correctamente";
                case SignInStatus.Failure:
                    return "Hubo un error al ingresar los datos. Intente nuevamente";
                case SignInStatus.RequiresVerification:
                    return "Necesita verificación del mail";
                default:
                    return "Caíste en el default";
            }

        }


    }

}