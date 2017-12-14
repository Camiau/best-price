using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class UsersApi
    {
        public bool RegisterUser(RegisterModel newUser)
        {
            var user = UserExist(newUser.Email, newUser.Dni);

            if (user == null)
            {
                ApplicationUser saveuser = new ApplicationUser()
                {
                    Name = newUser.Name,
                    Surname = newUser.Surname,
                    Dni = newUser.Dni,
                    Email = newUser.Email,
                    EmailIsConfirmed = true
                };
                return PersistenceData.RegisterUser(saveuser);
            }
            
            else return false;
        }

        public bool Login(LoginModel userLogin)
        {

            var user = UserExist(userLogin.Email, userLogin.Dni);

            if (user != null && user.EmailIsConfirmed)
            {
                return true;
            }

            else if (user != null && !user.EmailIsConfirmed)
            {
                return false;
            }

            else return false;
        }

        public static ApplicationUser UserExist(string email, long dni)
        {
            //var userexist = PersistenceData.usersdb.Find(u => u.Email == email && u.Dni == dni);
            var persistence = new PersistenceData();
            var userexist = persistence.UserExist(email,dni);
            return userexist;
        }

    }
}