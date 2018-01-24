using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MejorPrecio.MvcView.Models
{
    public class RegisterPriceModel
    {
        public Guid IdProduct { get; set; } //foreign key from a specific product
        [Required]
        private decimal priceEffective { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Guid IdUser { get; set; }

        public decimal PriceEffective { get => priceEffective; set => priceEffective = value; }
    }
}