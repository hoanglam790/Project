namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plan")]
    public partial class Plan
    {
        public int PlanID { get; set; }

        public DateTime Calendar { get; set; }

        public int TimeID { get; set; }

        public int DistributorID { get; set; }

        [Required]
        [StringLength(250)]
        public string PurposeVisit { get; set; }

        [Required]
        [StringLength(150)]
        public string Guest { get; set; }

        public int Status { get; set; }

        public virtual Distributor Distributor { get; set; }

        public virtual Time Time { get; set; }
    }
}
