using System;
using System.Collections.Generic;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class ProductsApi
    {
        private ProductRepository db = new ProductRepository();

        public Product SearchByCodeBar(string codeBar)
        {
            //codeBar is a valid codeBar cheched by a previous function
            return db.GetProductByCodeBar(codeBar);
        }

        public List<Product> ReadAllProducts()
        {
            return db.ReadAllProducts();
        }

        public bool Register(ProductRegister newProduct)
        {
            var productExists = db.GetProductByCodeBar(newProduct.CodeBar);

            if (productExists != null)
            {
                return false;
            }

            else
            {
                Product product = new Product()
                {
                    CodeBar = newProduct.CodeBar,
                    Description = newProduct.Description
                };
                db.RegisterProduct(product);
                return true;
            }
        }

        public bool Delete(string barCode)
        {
            var productExists = db.GetProductByCodeBar(barCode);
            if(productExists == null)
            {
                return false;
            }
            else
            {
                db.DeleteProduct(productExists.IdProduct);
                return true;
            }

        }
    }
}
