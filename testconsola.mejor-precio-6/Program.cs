using System;
using MejorPrecio.Common;
using MejorPrecio.Api;
namespace testconsola.mejor_precio_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var product1 = new ProductsApi();
            long parameter =0;
            var p=product1.SearchByCodeBar(parameter);
        }
    }
}
