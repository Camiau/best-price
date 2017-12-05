using System;
using System.Collections.Generic;
using MejorPrecio.Common;

namespace MejorPrecio.Api 
{
    public class UsersApi
    {
        private List<User> users = new List<User> (); //Falsa persistencia

        public bool RegisterUser (RegisterModel newUser) 
        {

            User user = new User () 
            {
                Name =  newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
                Dni = newUser.Dni,
                EmailIsConfirmed = false
            };
            users.Add(user);
            return true;
        }

        public bool Login (LoginModel user)
        {
            var userInList = users.Find(u => u.Email == user.Email);

            if(userInList != null && userInList.EmailIsConfirmed)
            {
                return true;
            }
            else return false;
        }
    }
}