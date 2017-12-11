using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class UsersApi
    {
        public ApplicationUser RegisterUser(RegisterModel newUser)
        {
            if(newUser.ValidateDni(newUser.Dni))
            {
                var user = UserExist(newUser.Email, newUser.Dni);
                
                if (user == null) //Si el usuario es null significa que no está en la DB
                {
                    ApplicationUser saveuser = new ApplicationUser()
                    {
                        Name = newUser.Name,
                        Surname = newUser.Surname,
                        Dni = newUser.Dni,
                        Email = newUser.Email,
                        EmailIsConfirmed = false
                    };
                    PersistenceData.RegisterUser(saveuser);
                    return saveuser;
                }
                

                else // De otra forma devolvemos los datos del usuario 
                {
                    user.EmailIsConfirmed = true; // Mockeamos la cosa que dice que el usuario está validado. Esto después se tiene que ir >.<
                    return user;
                };

            }
            else return null;
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

        private static ApplicationUser UserExist(string email, string dni)
        {
            var userexist = PersistenceData.usersdb.Find(u => u.Email == email && u.Dni == dni);
            return userexist;
        }

    }
}