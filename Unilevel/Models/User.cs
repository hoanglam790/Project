namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(250)]
        public string FullName { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public int RoleID { get; set; }

        public int AreaID { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(250)]
        public string Reporter { get; set; }

        public virtual Area Area { get; set; }

        public virtual Role Role { get; set; }
    }
}