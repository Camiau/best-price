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
            //Console.WriteLine("Hello World!");
            var apiProduct = new ProductsApi();
            var product1=new Product();
            product1.CodeBar = "0123456789012";
            var p = apiProduct.FindBestPrice(product1);
            System.Console.WriteLine("ID:"+p[0].IdUser.ToString());
            System.Console.WriteLine("ID:"+p[1].IdUser.ToString());
            System.Console.WriteLine("ID:"+p[2].IdUser.ToString());
            System.Console.WriteLine("ID:"+p[3].IdUser.ToString());
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

