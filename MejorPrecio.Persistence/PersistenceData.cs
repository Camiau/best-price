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
            var ret = new Product();
            return ret;
        }
        public List<Price> GetBestPrice(Product prd)
        {
            List<Price> productList = new List<Price>();
            var today = new DateTimeOffset();
            for (int i = 0; i < 10; i++)
            {
                var prod = new Price();
                prod.PriceEffective = 50.00;
                prod.Lattitude = -66.6666;
                prod.Longittude = -66.6666;
                prod.Date = today.Date;
                prod.PriceEffective++;
                prod.Id=i+10;
                prod.IdUser = i;
                productList.Add(prod);
            }
            return productList;
        }
        public bool RegisterPrice(Product prd, Price priceEspecific)
        {
            return true;
        }
    }
}
