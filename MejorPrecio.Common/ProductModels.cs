using System;


namespace MejorPrecio.Common
{
    public class Product
    {
        public Guid IdProduct;
        public string BarCode;
        public string NameProduct;
        public string Brand;
        public string Description;
        public string ImgSrc;
    }
    public class ProductRegister
    {
        public string BarCode;
        public string Description;
        public string Brand;
        public string NameProduct;
        public string ImgSrc;
        public ProductRegister(string barCode, string description)
        {
            this.BarCode = barCode;
            this.Description = description;
        }
        public ProductRegister()
        {

        }
    }
}
