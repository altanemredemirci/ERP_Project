using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP.Entity.ViewModels
{
    public class RegisterModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        [MaxLength(200,ErrorMessage ="Adres tanımı maximum 200 karakter girilebilir.")]
        [MinLength(5,ErrorMessage ="Adres tanımı minumum 5 karakter girilebilir.")]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}