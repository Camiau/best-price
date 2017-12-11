using System;
using System.Text.RegularExpressions;

namespace MejorPrecio.Common {
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

        public bool ValidateDni(string dni)
        {
            string pattern = @"\b\d{8}";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            Match match = rgx.Match(dni);
            return match.Success;
            
        }
    }

    public class LoginModel 
    {
        public string Email { get; set; }
        public string Dni { get; set; }
    }

}