﻿using System;
using MejorPrecio.Common;
using System.Collections.Generic;
using System.IO;
using MejorPrecio.Api;
using System.Text.RegularExpressions;// For regex

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
                            //BestPricesForAProduct();
                            break;
                        case 1:
                            //Fer();
                            break;
                        case 3:
                            //Cami();
                            break;
                        case 2:
                            //userLogins();
                            break;
                        case 5:
                            Gasti();
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
            var nRole= new RolesApi();
            var lstRoles= nRole.GetAllRoles();
            System.Console.WriteLine("IdRol:"+lstRoles[0].Id.ToString()+"Role:"+lstRoles[0].RoleName);
            System.Console.WriteLine("IdRol:"+lstRoles[1].Id.ToString()+"Role:"+lstRoles[1].RoleName);
            System.Console.WriteLine("IdRol:"+lstRoles[2].Id.ToString()+"Role:"+lstRoles[2].RoleName);
        }
        /*static private void Fer()
        {
            UsersApi api = new UsersApi();
            SimpleUserModel userLogin = new SimpleUserModel();
            RegisterModel newUser = new RegisterModel();

            Console.WriteLine("Ingrese su nombre");
            newUser.Name = Console.ReadLine();

            Console.WriteLine("Ingrese su apellido");
            newUser.Surname = Console.ReadLine();

            Console.WriteLine("Ingrese su email");
            newUser.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su dni");
            newUser.Dni = Console.ReadLine();

            var resultado = api.RegisterUser(newUser);
            Console.WriteLine("{0}", resultado);
            var usrModel = new SimpleUserModel(newUser.Email, newUser.Dni);
            var confirmInProgress = api.ConfirmEmail(usrModel);

            Console.WriteLine("\n\n\nValidando email!!");

            Console.WriteLine("\n\n\n{0}", confirmInProgress);


            Console.WriteLine("\n\n\nIngresando al sistema!!");


            Console.WriteLine("Ingrese su email");
            userLogin.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su dni");
            userLogin.Dni = Console.ReadLine();

            var result = api.Login(userLogin);
            Console.WriteLine("{0}", result);

        }*/
        /*static private string Cami()
        {
            //PRUEBA
            var scanner = new BarcodeScanner();

            string code = scanner.ScanBarcode(@"C:\Users\camilaf_lu\Pictures\barcode-cocacola.jpg");//Cambiar path imagen

            if (code != null)
            {
                Console.WriteLine("Barcode: " + code);
            }
            else
            {
                Console.WriteLine("No se pudo leer el codigo");
            }
            return code;
        }*/

        /*static private void userLogins()
        {
            UsersApi api = new UsersApi();
            SimpleUserModel userLogin = new SimpleUserModel();

            Console.WriteLine("Ingrese su email");
            userLogin.Email = Console.ReadLine();

            Console.WriteLine("Ingrese su dni");
            userLogin.Dni = Console.ReadLine();

            var dataOfUser = api.Login(userLogin);
            Console.WriteLine(dataOfUser);
        }*/

        /*static private void BestPricesForAProduct()
        {
            var apiPro = new ProductsApi();
            var apiPrice = new PricesApi();
            var scanner = new BarcodeScanner();

            var product = apiPro.SearchByCodeBar(scanner.ScanBarcode(@"C:\Users\camilaf_lu\Pictures\barcode-cocacola.jpg"));
            Console.WriteLine(product.Description);

            if (product.CodeBar == null)
            {
                Console.WriteLine("Codigo inexistente");
                return;
            }

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
            

        }*/
    }

}

