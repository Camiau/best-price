using System;

namespace MejorPrecio.MvcView.Models
{
    public class RegisterPriceModel
    {
        public Guid IdProduct;//foreign key from a specific product
        public decimal PriceEffective;
        public DateTimeOffset Date;
        public double Latitude;
        public double Longitude;
        public Guid IdUser;
    }
}