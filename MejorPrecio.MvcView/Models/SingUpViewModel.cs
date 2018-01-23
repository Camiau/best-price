using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MejorPrecio.MvcView.Models
{
    public class SigUpViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Email { get; set; }
    }
}