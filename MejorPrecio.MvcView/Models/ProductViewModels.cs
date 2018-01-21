using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MejorPrecio.MvcView.Models
{
    public class ProductRegisterViewModel
    {
        [Required]
        public string Description { get; set; }
        public string Brand { get; set; }
        public string ProductName { get; set; }
        public string BarCode { get; set; }

    }


}