using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace movietest1.Models
{
    public class Account
    {
        
        
        public string ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public string Role { get; set; }
        
    }
}