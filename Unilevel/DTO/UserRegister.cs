using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class UserRegister
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Please enter a password at least 8 characters !!!")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Name { get; set; }
        public int Role { get; set; }
        public int Area { get; set; }
        public int Status { get; set; }
    }
}