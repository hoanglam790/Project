using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class ResetPassword
    {
        [Required]
        [EmailAddress]
        public string Token { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Please enter a password at least 8 characters !!!")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}