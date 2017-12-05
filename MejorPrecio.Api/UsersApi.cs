using System;
using System.Collections.Generic;
using MejorPrecio.Common;

namespace MejorPrecio.Api 
{
    public class UsersApi
    {
        private List<ApplicationUser> users = new List<ApplicationUser> (); //Falsa persistencia

        public bool RegisterUser (RegisterModel newUser) 
        {

            ApplicationUser user = new ApplicationUser () 
            {
                Name =  newUser.Name,
                Surname = newUser.Surname,
                Email = newUser.Email,
                Dni = newUser.Dni,
                EmailIsConfirmed = true
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