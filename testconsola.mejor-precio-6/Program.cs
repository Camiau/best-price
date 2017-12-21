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
                Console.WriteLine("1-Registrarse\n2-Login\n3-Escanear código de barras\n4-Buscar mejor precio para un producto\n");
                string opt = Console.ReadLine();
                if (Int32.TryParse(opt, out int number))
                {
                    switch (number)
                    {
                        case 4:
                            BestPricesForAProduct();
                            break;
                        case 1:
                            Fer();
                            break;
                        case 3:
                            Cami();
                            break;
                        case 2:
                            userLogins();
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

        static private void userLogins()
        {
            UsersApi api = new UsersApi();
            LoginModel userLogin = new LoginModel();

            Console.WriteLine("Ingrese su email");
            userLogin.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su dni");
            userLogin.Dni = int.Parse(Console.ReadLine());

            var dataOfUser = api.Login(userLogin); 
            Console.WriteLine(dataOfUser);
        }

        static private void BestPricesForAProduct()
        {
            var apiPro = new ProductsApi();
            var apiPrice = new PricesApi();

            var product = apiPro.SearchByCodeBar("0123456789012");
            Console.WriteLine(product.Description);

            var bestPricesList = apiPrice.FindBestPrice(product);

            Console.WriteLine("Mejores precios:");
            for (int i = 0; i < bestPricesList.Count; i++)
            {
                Console.WriteLine("$ " + bestPricesList[i].PriceEffective);
            }
            /*
            buscar el producto por codigo de barras
            HACER:
            si existe mostrar datos y mejores precios
            si no existe dar la opcion de cargar un nuevo barcode con descripcion y nuevo precio
             */
          
        }
    }

}

