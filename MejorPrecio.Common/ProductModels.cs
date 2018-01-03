using System;


namespace MejorPrecio.Common
{
    public class Product
    {
        public int Id;
        public string BarCode;
        public string Description;
    }
    public class ProductRegister
    {
        public string BarCode;
        public string Description;
        public ProductRegister(string barCode,string description)
        {
            this.BarCode=barCode;
            this.Description=description;
        }
        public ProductRegister()
        {
           
        }
    }
}
