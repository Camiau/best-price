using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class UsersApi
    {
        UserRepository db = new UserRepository();
        /// <summary>
        ///  Servira de auxilio para devolver los estados del login del usuario
        /// </summary>
        public enum SignInStatus
        {
            Success,
            Failure,
            RequiresVerification
        }

        /// <summary>
        ///  Servira de auxilio para devolver los estados del registro de usuario
        /// </summary>
        public enum SignUpStatus
        {
            Success,
            Failure

        }
        public SignUpStatus RegisterUser(RegisterModel newUser)
        {
            var userExist = db.UserExist(newUser.Email, newUser.Dni);
            if (userExist == null)
            {
                ApplicationUser saveuser = new ApplicationUser()
                {
                    Name = newUser.Name,
                    Surname = newUser.Surname,
                    Dni = newUser.Dni,
                    Email = newUser.Email,
                    EmailIsConfirmed = false
                };
                return SignUpStatus.Success;
        
            }
            else 
            {
                return SignUpStatus.Failure;
            }
        }

        public SignInStatus Login(LoginModel userLogin)
        {
            var user = db.UserExist(userLogin.Email, userLogin.Dni);

            if (user == null)
            {
                return SignInStatus.Failure;
            }
            if (!user.EmailIsConfirmed)
            {
                return SignInStatus.RequiresVerification;
            }
            else
            {
                return SignInStatus.Success;
            }
            /*switch (result)
            {
                case UserRepository.SignInStatus.Success:
                    //Debería crearse la cookie aquí
                    return userManager.logedIn.Email.ToString();
                case UserRepository.SignInStatus.Failure:
                    return "Correo electrónico o DNI no existentes";
                case UserRepository.SignInStatus.RequiresVerification:
                    return "Necesita verificación del mail";
                default:
                    return "Caíste en el default";
            }
            Por si lo necesitamos en un futuro*/

        }

        public bool? ConfirmEmail(string email, string dni)  
        {

            var result = db.UserExist(email, dni);
            if(result == null)
            {
                return null;
            }
            else if (result != null && !result.EmailIsConfirmed)
            {
                db.ConfirmEmail(result);
                return true;
            }
            else
            {
                return false;
            }


            
            /* switch (result)
            {
                case true:
                    //Aquí debería crearse la cookie
                    return "Email validado correctamente";
                case false:
                    return "El email ya está validado";
                default: 
                    return "El email no existe";
            } */

        }


    }

}