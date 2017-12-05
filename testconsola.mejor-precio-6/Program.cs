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

        }
        static private void Cami()
        {
             //PRUEBA
            var code = new BarcodeScanner();
            
            code.ScanBarcode(@"C:\Users\camilaf_lu\Pictures\img-codbarra.jpg");//Cambiar path imagen

            if(code.codebar != null)
            {
                Console.WriteLine("Barcode: " + code.codebar );
            }
            else
            {
                Console.WriteLine("No se pudo leer el codigo");
            }
            Console.Read();
        }
    }
}
