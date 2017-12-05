<<<<<<< HEAD
﻿using System;
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
            var productPhisic=new Product();
            var ls= product1.FindBestPrice(productPhisic);
        }
        static private void Fer()
        {

        }
        static private void Cami()
        {

        }
    }
}
=======
﻿using System;
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

            RegisterModel newUser = new RegisterModel()
            {
                Name = "Nombre",
                Surname = "Apellido",
                Email = "correo@dominio.com",
                Dni = "12345678"
            };

            if (api.RegisterUser(newUser))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Usuario añadido correctamente!");
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

>>>>>>> issue-29
