using System;

namespace MejorPrecio.Common
{
    public class Price
    {
        public int Id;
        public string CodeBar;//foreign key from a specific product
        public double PriceEffective;
        public DateTimeOffset Date;
        public double Lattitude;
        public double Longittude;
        public int IdUser;
    }
}
