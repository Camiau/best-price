using System;
using System.Collections.Generic;
using MejorPrecio.Common;
namespace MejorPrecio.Persistence
{
    public class PersistenceData
    {
        public static List<ApplicationUser> usersdb = new List<ApplicationUser>();

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
        public static ApplicationUser UserExist(string email, string dni)
        {
            var userexist = PersistenceData.usersdb.Find(u => u.Email == email && u.Dni == dni);
            return userexist;
        }
        public static bool RegisterUser(ApplicationUser user)
        {
            usersdb.Add(user);
            return true;
        }

        public Product GetProductByCodeBar(string codeBar)
        {
            var ret = new Product();
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
        public bool RegisterPrice(Product prd, Price priceEspecific)
        {
            return true;
        }
    }
}
