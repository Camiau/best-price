using System;

namespace MejorPrecio.Common
{
    public class Price
    {
        public Guid Id;
        public Guid IdProduct;//foreign key from a specific product
        public decimal PriceEffective;
        public DateTimeOffset Date;
        public double Latitude;
        public double Longitude;
        public Guid IdUser;
    }
}
