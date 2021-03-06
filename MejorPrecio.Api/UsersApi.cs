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
        public Role GetCurrentRole()
        {
            var myRole = new RoleRepository();
            return myRole.GetRoleByIdRole(this.pvrUser.IdRol);
        }
        private ApplicationUser pvrUser = null;
        public ApplicationUser LoggedUser { get { return pvrUser; } }
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
        public enum UserStatus
        {
            EmailExits,
            DniExits,
            UserExist,
            OkToContinue
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
                saveuser.ImagePath= newUser.ImagePath;
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
            var newUser = db.UserExist(userLogin.Email, userLogin.Dni);
            if (newUser == null)
            {
                return SignInStatus.Failure;
            }
            if (!newUser.EmailIsConfirmed)
            {
                return SignInStatus.RequiresVerification;
            }
            else
            {
                pvrUser = newUser;
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

        public ApplicationUser GetUserById(Guid idUser)
        {
            var data = new UserRepository();
            return data.GetUserById(idUser);
        }
        public UserStatus CheckUser(string email, string dni)
        {
            var data = new UserRepository();
            var chEmail = data.EmailExits(email);
            var chDni = data.DniExits(dni);
            if (chEmail==true && chDni==true)
            {
                return UserStatus.UserExist;
            }
            if (chEmail==true)
            {
                return UserStatus.EmailExits;
            }
            if (chDni==true)
            {
                return UserStatus.DniExits;
            }
            return UserStatus.OkToContinue;
        }
    }

}