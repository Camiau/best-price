using System;
using System.Collections.Generic;
using System.IO;
using MejorPrecio.Common;
using MejorPrecio.Persistence;

namespace MejorPrecio.Api
{
    public class ProductsApi
    {
        private ProductRepository db = new ProductRepository();
        private BarcodeScanner scanner = new BarcodeScanner();

        public string GetBarcode (Stream str)
        {
            return scanner.ScanBarcode(str);

        }
        public Product SearchByBarCode(string barCode)
        {
            //codeBar is a valid codeBar cheched by a previous function
            return db.GetProductByBarCode(barCode);
        }

        public List<Product> ReadAllProducts()
        {
            return db.ReadAllProducts();
        }

        public Guid Register(ProductRegister newProduct)
        {
            var productExists = db.GetProductByBarCode(newProduct.BarCode);

            if (productExists != null)
            {
                throw new ArgumentException("Existe el producto para el código de barras: " + newProduct.BarCode);

            }

            else
            {
                Product product = new Product()
                {
                    BarCode = newProduct.BarCode,
                    Description = newProduct.Description
                };

                db.RegisterProduct(product);

                productExists = db.GetProductByBarCode(product.BarCode);

                return productExists.IdProduct;
            }
        }

        public void Delete(string barCode)
        {
            var product = db.GetProductByBarCode(barCode);

            if (product == null)
            {
                throw new ArgumentException("No existe producto para el código de barras: " + barCode);
            }

            db.DeleteProduct(product.IdProduct);
        }
    }
}
