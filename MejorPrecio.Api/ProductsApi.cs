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
            var persistenceProduct = new ProductRepository();
            return persistenceProduct.GetProductByCodeBar(codeBar);
        }
        public List<Product> ReadAllProducts()
        {
            var persistenceProduct = new ProductRepository();
            return persistenceProduct.ReadAllProducts();
        }
    }
}
