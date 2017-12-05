using System;
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
    }
}
