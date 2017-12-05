using System;
using System.Collections.Generic;
using MejorPrecio.Common;

namespace MejorPrecio.Front
{
    public class FrontI
    {
        public bool RegisterProduct(Product prod, Price price1)
        {
            return true;
        }
        public bool RegisterUser(string name, string lastName, long dni, string mail, byte[] photoDni)
        {
            return true;
        }
        public bool LogInUser(string mail, string dni)
        {
            return true;
        }
        public string GetCodeByPhoto(byte[] photoCodeBar)
        {
            return "1234567891234";
        }
        public bool RegisterNewPrice(string codeBar, Price price1)
        {
            return true;
        }
        public List<Product> GetProductByCodeBar(string codeBar)
        {
            var prod = new Product();
            List<Product> productList = new List<Product>();
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            productList.Add(prod);
            return productList;
        }
    }
}
