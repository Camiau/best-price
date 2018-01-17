using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MejorPrecio.MvcView.Models
{
    public class LogInViewModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
    }
}