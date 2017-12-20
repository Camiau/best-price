using System;

namespace MejorPrecio.Common
{
    public class Price
    {
        public int Id;
        public int idProduct;//foreign key from a specific product
        public decimal PriceEffective;
        public DateTimeOffset Date;
        public double Lattitude;
        public double Longittude;
        public int IdUser;
    }
}
