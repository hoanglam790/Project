namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Distributor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Distributor()
        {
            ChiTiet_Distributors = new HashSet<ChiTiet_Distributors>();
        }

        public int DistributorID { get; set; }

        [Required]
        [StringLength(250)]
        public string DistributorName { get; set; }

        [Required]
        [StringLength(250)]
        public string DistributorAddress { get; set; }

        [Required]
        [StringLength(250)]
        public string DistributorEmail { get; set; }

        [Required]
        [StringLength(11)]
        public string DistributorPhone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet_Distributors> ChiTiet_Distributors { get; set; }
    }
}
