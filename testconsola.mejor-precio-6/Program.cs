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
