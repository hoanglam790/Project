namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Area")]
    public partial class Area
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Area()
        {
            ChiTiet_Distributors = new HashSet<ChiTiet_Distributors>();
        }

        public int AreaID { get; set; }

        public int AreaCode { get; set; }

        [Required]
        [StringLength(250)]
        public string AreaName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_Distributors> ChiTiet_Distributors { get; set; }
    }
}
