using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MejorPrecio.MvcView.Models
{
    public class LogInViewModel
    {
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Email { get; set; }
    }
    /*public class LoggedInViewModel
    {
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Email { get; set; }
    }*/
}