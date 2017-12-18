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
        public enum SignInStatus
        {
            Success,
            Failure,
            RequiresVerification
        }
        public static Task<ApplicationUser> ConfirmEmailAsync(string email)

        {
            var result = PersistenceData.usersdb.Find(u => u.email == email);
            if (result != null)
            {
                result.EmailIsConfirmed = true;
                return Task.FromResult<ApplicationUser>(result);
            }
            else return Task.FromResult<ApplicationUser>(result); ;

        }

        public static Task<SignUpStatus> CreateUserAsync(RegisterModel user)
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
                PersistenceData.usersdb.Add(saveuser); //Cambiar esto por la persistencia verdadera

                return Task.FromResult<SignUpStatus>(SignUpStatus.Success);

            }

            else
            {
                return Task.FromResult<SignUpStatus>(SignUpStatus.Failure);
            }

        }


        public static async Task<SignInStatus> Login(LoginModel userLogin)
        {

            var user = await UserManager.UserExist(userLogin.Email, userLogin.Dni);
            if (user == null)
            {
                //return Task.FromResult<SignInStatus>(SignInStatus.Failure);
                return SignInStatus.Failure;
            }
            if (!user.EmailIsConfirmed)
            {
                //return Task.FromResult<SignInStatus>(SignInStatus.RequiresVerification);
                return SignInStatus.RequiresVerification;
            }

            else
                //return Task.FromResult<SignInStatus>(SignInStatus.Success);
                return SignInStatus.Success;
        }

        private static Task<ApplicationUser> UserExist(string email, long dni)
        {
            //var user = PersistenceData.usersdb.Find(u => u.Email == email && u.Dni == dni); //Cambiar esto por la persistencia verdadera
            //return user;
            ApplicationUser user = new ApplicationUser();
            return Task.FromResult<ApplicationUser>(PersistenceData.usersdb.Find(u => u.Email == email && u.Dni == dni));
        }

    }

    /// <summary>
    ///  Servira de auxilio para devolver los estados del login del usuario
    /// </summary>


    /// <summary>
    ///  Servira de auxilio para devolver los estados del registro de usuario
    /// </summary>
    public enum SignUpStatus
    {
        Success,
        Failure,

    }
}