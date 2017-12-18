namespace MejorPrecio.Common
{
    public class ApplicationUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long Dni { get; set; }
        public bool EmailIsConfirmed { get; set; }
        public string ImagePath { get; set; }
        public Role RoleId { get; set; }

    }
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public long Dni { get; set; }

    }

    public class LoginModel
    {
        public string Email { get; set; }
        public long Dni { get; set; }
    }
    

}