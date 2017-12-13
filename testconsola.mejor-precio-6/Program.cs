﻿using System;
using MejorPrecio.Common;
using MejorPrecio.Api;
namespace testconsola.mejor_precio_6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Gasti();
            Fer();
            Cami();*/
            while(true)
            {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine("\t\tMEJOR - PRECIO - 6");
            Console.WriteLine("Ingrese número de opción");
            Console.WriteLine("1-Registrarse\n2-Escanear código de barras\n3-Listar precios\n");
            string opt = Console.ReadLine();
            if (Int32.TryParse(opt, out int number))
            {
                switch (number)
                {
                    case 3:
                        Gasti();
                        break;
                    case 1:
                        Fer();
                        break;
                    case 2:
                        Cami();
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;

                }

            }

            }
        }
        static private void Gasti()
        {
            //Console.WriteLine("Hello World!");
            var os = Environment.OSVersion;
            System.Console.WriteLine("OS:"+os.Platform.ToString());
            var apiProduct = new ProductsApi();
            var product1 = new Product();
            product1.CodeBar = Cami();
            product1.Description = "Lata de cocacola";
            var p = apiProduct.FindBestPrice(product1);
            Console.WriteLine(product1.Description);
            System.Console.WriteLine("Price:"+p[0].PriceEffective.ToString());
            System.Console.WriteLine("Price:"+p[1].PriceEffective.ToString());
            System.Console.WriteLine("Price:"+p[2].PriceEffective.ToString());
            System.Console.WriteLine("Price:"+p[3].PriceEffective.ToString());
            var okLoad=apiProduct.LoadNewPrice(p[0]);
           // System.Console.WriteLine("Se pudo carga el nuevo precio?"+okLoad.ToString());
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
        static private string Cami()
        {
            //PRUEBA
            var code = new BarcodeScanner();

            code.ScanBarcode(@"C:\Users\camilaf_lu\Pictures\barcode-cocacola.jpg");//Cambiar path imagen

            if (code.codebar != null)
            {
                Console.WriteLine("Barcode: " + code.codebar);
            }
            else
            {
                Console.WriteLine("No se pudo leer el codigo");
            }
            return code.codebar;
        }
    }

}

