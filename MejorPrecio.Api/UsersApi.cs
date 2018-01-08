using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MejorPrecio.Common;
using MejorPrecio.Persistence;
using System.Diagnostics;

namespace MejorPrecio.Api
{
    public class UsersApi
    {
        public Role GetRole()
        {
            var myRole = new Role();
            myRole.Id=3;
            myRole.RoleName="Administrador";
            return myRole;
        }
        public enum SignInStatus
        {
            Success,
            Failure,
            RequiresVerification
        }
        public enum SignUpStatus
        {
            Success,
            Failure
        }
        public SignUpStatus RegisterUser(RegisterModel newUser)
        {
            var db = new UserRepository();
            var userExist = db.UserExist(newUser.Email, newUser.Dni);
            if (userExist == null)
            {
                ApplicationUser saveuser = new ApplicationUser();
                saveuser.Name = newUser.Name;
                saveuser.Surname = newUser.Surname;
                saveuser.Dni = newUser.Dni;
                saveuser.Email = newUser.Email;
                saveuser.EmailIsConfirmed = false;
                var singUpStatus = db.CreateUser(saveuser);
                if (singUpStatus == true)
                {
                    return SignUpStatus.Success;
                }
                else
                {
                    return SignUpStatus.Failure;
                }
            }
            else
            {
                return SignUpStatus.Failure;
            }
        }

        public SignInStatus Login(SimpleUserModel userLogin)
        {
            var db = new UserRepository();
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

        public bool? ConfirmEmail(SimpleUserModel usrModel)
        {
            var email = usrModel.Email;
            var dni = usrModel.Dni;
            var db = new UserRepository();
            var result = db.UserExist(email, dni);
            if (result == null)
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