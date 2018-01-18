using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MejorPrecio.MvcView.Models
{
    public class RegisterPriceModel
    {
        public Guid IdProduct;//foreign key from a specific product
        [Required]
        private decimal priceEffective;
        [Required]
        public DateTimeOffset Date;
        public double Latitude;
        public double Longitude;
        public Guid IdUser;

        public decimal PriceEffective { get => priceEffective; set => priceEffective = value; }
    }
}