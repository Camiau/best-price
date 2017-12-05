using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class ProductsApi
    {

        public Product SearchByCodeBar(string codeBar)
        {
            //codeBar is a valid codeBar chechekd by a previous function
            var persistence= new PersistenceData();
            //here should be all the init for the DB
            return persistence.GetProductByCodeBar(codeBar);
        }
        public List<Product> FindBestPrice(Product prod)
        {
            var data=new PersistenceData();
            //Here will be all the init for the conecction to the DB
            return data.GetBestPrice(prod);
        }
    }
}
