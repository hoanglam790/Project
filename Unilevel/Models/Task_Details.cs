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

        public int Status { get; set; }

        public int Rating { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Comment { get; set; }

        public int? TaskID { get; set; }

        public int? UserID { get; set; }

        public virtual Task Task { get; set; }

        public virtual User User { get; set; }
    }
}
