using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MejorPrecio.Common
{
    /// <summary>
    ///  Manejara las operaciones de login, registro y validación del estado del usuario
    /// </summary>
    public class UserManager
    {
        private LoginModel _logedIn = new LoginModel();

        public LoginModel logedIn {get {return _logedIn;}}

        public static List<ApplicationUser> usersdb = new List<ApplicationUser>();


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
        public SignUpStatus CreateUser(RegisterModel user)
        {
            var userExist = UserExist(user.Email, user.Dni);
            if (userExist == null)
            {
                ApplicationUser saveuser = new ApplicationUser()
                {
                    Name = user.Name,
                    Surname = user.Surname,
                    Dni = user.Dni,
                    Email = user.Email,
                    EmailIsConfirmed = false
                };
                usersdb.Add(saveuser); //Cambiar esto por la persistencia verdadera

                return SignUpStatus.Success;

            }

            else
            {
                return SignUpStatus.Failure;
            }

        }


        public  SignInStatus Login(LoginModel userLogin)
        {

            var user = UserExist(userLogin.Email, userLogin.Dni);

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
                this._logedIn.Dni = user.Dni;
                this._logedIn.Email = user.Email;
                return SignInStatus.Success;
            }
        }

        private ApplicationUser UserExist(string email, long dni)
        {
            ApplicationUser user = new ApplicationUser();
            return usersdb.Find(u => u.Email == email && u.Dni == dni);
        }

        public bool? ConfirmEmail(string email, long dni)

        {
            var result = UserExist(email, dni);

            if (result != null && !result.EmailIsConfirmed)
            {
                result.EmailIsConfirmed = true;
                return true;
            }

            else return null;

        }
    }
}