using System;
using MejorPrecio.Common;

namespace MejorPrecio.Front
{
    public class FrontI
    {
        public bool RegisterProduct(Product prod,Price price1)
        {
            return true;
        }
        public bool RegisterUser(string name, string lastName,long dni,string mail,byte[] photoDni)
        {
            return true;
        }
    }
}
