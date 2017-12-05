using System;
using MejorPrecio.Api;
using MejorPrecio.Common;

namespace testconsola.mejor_precio_6
{
    class Program
    {
        static void Main(string[] args)
        {

            UsersApi api = new UsersApi();

            LoginModel userLogin = new LoginModel();

            RegisterModel newUser = new RegisterModel()
            {
             Name = "Nombre",
             Surname = "Apellido",
             Email = "correo@dominio.com",
             Dni = "12345678"
            };

            if(api.RegisterUser(newUser))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Usuario añadido correctamente!");
            }                        

            Console.WriteLine("Ingrese su email");

            userLogin.Email = Console.ReadLine();
        
            Console.WriteLine("Ingrese su dni");

            userLogin.Dni = Console.ReadLine();

            if(api.Login(userLogin))
            {
            Console.WriteLine("Logeado!");

            }
            else Console.WriteLine("No logeado :C");
        }
    }
}
