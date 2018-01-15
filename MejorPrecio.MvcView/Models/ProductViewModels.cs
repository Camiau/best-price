using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MejorPrecio.MvcView.Models
{
    public class ProductRegisterViewModel
    {
        
        public string description;
        [Required]
        public IFormFile file;
        

    }
}