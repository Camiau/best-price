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
            while (true)
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
            var os = Environment.OSVersion;
            System.Console.WriteLine("OS:" + os.Platform.ToString());
            var dateto = new DateTimeOffset();
            System.Console.WriteLine(dateto.Date);
            var apiProduct = new ProductsApi();
            var UsersApi = new UsersApi();
            var userToRegister = new RegisterModel();
            userToRegister.Name = "cami";
            userToRegister.Surname = "F";
            userToRegister.Email = "cami@f.com";
            userToRegister.Dni = 38243776;
            userToRegister.ImagePath = "";
            var okcreate = UsersApi.RegisterUser(userToRegister);
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

            newUser.Dni = int.Parse(Console.ReadLine());

            var resultado = api.RegisterUser(newUser);

            Console.WriteLine("{0}", resultado);      

            var confirmInProgress = api.ConfirmEmail(newUser.Email, newUser.Dni);

            Console.WriteLine("\n\n\nValidando email!!");

            Console.WriteLine("\n\n\n{0}", confirmInProgress);


            Console.WriteLine("\n\n\nIngresando al sistema!!");


            Console.WriteLine("Ingrese su email");

            userLogin.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su dni");

            userLogin.Dni = int.Parse(Console.ReadLine());

            var result = api.Login(userLogin);
            
            Console.WriteLine("{0}", result);

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

