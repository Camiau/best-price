using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MejorPrecio.Common
{
    public class ApplicationUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Dni { get; set; }
        public bool EmailIsConfirmed { get; set; }

    }
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Dni { get; set; }

    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Dni { get; set; }
    }


}