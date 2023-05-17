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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Area_Users = new HashSet<Area_Users>();
        }

        public int UserID { get; set; }

        [Required]
        [StringLength(250)]
        public string FullName { get; set; }

        [Required]
        [StringLength(250)]
        public string Email { get; set; }

        public byte[] PasswordHashing { get; set; }

        public byte[] PasswordSalting { get; set; }

        public int RoleID { get; set; }

        public int? AreaID { get; set; }

        public int Status { get; set; }

        public string VerifyToken { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public string PasswordReset { get; set; }

        public DateTime? ResetToken { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area_Users> Area_Users { get; set; }

        public virtual Role Role { get; set; }
    }
}
