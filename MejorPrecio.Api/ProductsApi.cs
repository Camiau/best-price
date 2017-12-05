using System;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class ProductsApi
    {

        public Product SearchByCodeBar(long codeBar)
        {
            //codeBar is a valid codeBar chechekd by a previous function
            var ret = new Product();
            var test= new PersistenceData();
            test.Prueba();
            return ret;
        }
    }
}
