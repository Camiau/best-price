using System;


namespace MejorPrecio.Common
{
    public class Product
    {
        public int IdProduct;
        public string CodeBar;
        public string Description;
    }
    public class ProductRegister
    {
        public string CodeBar;
        public string Description;
        public ProductRegister(string CodeBar,string Description)
        {
            this.CodeBar=CodeBar;
            this.Description=Description;
        }
        public ProductRegister()
        {
           
        }
    }
}
