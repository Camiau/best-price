using System;
namespace MejorPrecio.Common {
    public class ApplicationUser 
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long Dni { get; set; }
        public bool EmailIsConfirmed { get; set; }
        public string ImagePath { get; set; }
        public int IdRol{ get; set; }

    }
    public class RegisterModel 
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long Dni { get; set; }
        public string Password { get; set; }
    }

    public class LoginModel 
    {
        public string Email { get; set; }
        public long Dni { get; set; }
    }
}