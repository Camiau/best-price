using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MejorPrecio.MvcView.Models
{
    public class ProductRegisterViewModel
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Description { get; set; }
        
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Brand { get; set; }
        //public string ProductName { get; set; }
        public string BarCode { get; set; }

    }


}