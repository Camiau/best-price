using System;
using MejorPrecio.Common;

namespace testconsola.mejor_precio_6
{
    class Program
    {
        static void Main(string[] args)
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
            //

        }
    }
}
