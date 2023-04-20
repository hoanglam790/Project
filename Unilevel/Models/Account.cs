namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public int AccountID { get; set; }

        [Required]
        [StringLength(200)]
        public string UserName { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        [StringLength(250)]
        public string DisplayName { get; set; }
    }
}
