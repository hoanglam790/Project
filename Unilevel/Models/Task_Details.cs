namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task_Details
    {
        [Key]
        public int TaskDetailsID { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        public int Rating { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Comment { get; set; }

        public int TaskID { get; set; }

        public virtual Task Task { get; set; }
    }
}
