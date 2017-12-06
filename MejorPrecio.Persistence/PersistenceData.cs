using System;
using System.Collections.Generic;
using MejorPrecio.Common;
namespace MejorPrecio.Persistence
{
    public class PersistenceData
    {
        public List<Product> ReadAllProducts()
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
        public bool UserExits(ApplicationUser user)
        {
            return true;
        }
        public bool RegisterUser(RegisterModel user)
        {
            return true;
        }

        public Product GetProductByCodeBar(string codeBar)
        {
            var ret=new Product();
            return ret;
        }
        public List<Product> GetBestPrice(Product prd)
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
        public bool RegisterPrice(Product prd,Price priceEspecific)
        {
            return true;
        }
    }
}
