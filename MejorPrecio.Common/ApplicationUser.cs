using System;
namespace MejorPrecio.Common
{
    public class ApplicationUser
    {
        public Guid IdUser {get;set;}
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public bool EmailIsConfirmed { get; set; }
        public string ImagePath { get; set; }
        public Guid IdRol { get; set; }

    }
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Dni { get; set; }

        public string ImagePath{get;set;}

    }

    public class SimpleUserModel
    {
        public string Email { get; set; }
        public string Dni { get; set; }
        public SimpleUserModel(string email,string dni)
        {
            this.Email=email;
            this.Dni=dni;
        }
        public SimpleUserModel()
        {
        }
    }
}