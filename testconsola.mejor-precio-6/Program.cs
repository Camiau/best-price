using System;
using MejorPrecio.Common;
using MejorPrecio.Api;
namespace testconsola.mejor_precio_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Gasti();
            Fer();
            Cami();
        }
        static private void Gasti()
        {
            Console.WriteLine("Hello World!");
            var product1 = new ProductsApi();
            string parameter = "0";
            var p = product1.SearchByCodeBar(parameter);
        }
        static private void Fer()
        {
            UsersApi api = new UsersApi();

            LoginModel userLogin = new LoginModel();

            RegisterModel newUser = new RegisterModel();

            Console.WriteLine("Ingrese su nombre");

            newUser.Name = Console.ReadLine();

            Console.WriteLine("Ingrese su apellido");

            newUser.Surname = Console.ReadLine();

            Console.WriteLine("Ingrese su email");

            newUser.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su dni");

            newUser.Dni = Console.ReadLine();


            if (api.RegisterUser(newUser))
            {
                Console.WriteLine("Usuario añadido correctamente!");
                Console.WriteLine("\n\n\nIngresando al sistema!!");
            }

            Console.WriteLine("Ingrese su email");

            userLogin.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su dni");

            userLogin.Dni = Console.ReadLine();

            if (api.Login(userLogin))
            {
                Console.WriteLine("Logeado!");

            }
            else Console.WriteLine("No logeado :C");

        }
        static private void Cami()
        {

        }
    }

}

