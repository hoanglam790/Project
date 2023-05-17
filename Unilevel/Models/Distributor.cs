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
            Area_Distributors = new HashSet<Area_Distributors>();
            Plans = new HashSet<Plan>();
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

        public int? AreaID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area_Distributors> Area_Distributors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
