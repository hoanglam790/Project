namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Notification")]
    public partial class Notification
    {
        public int NotificationID { get; set; }

        [Required]
        [StringLength(150)]
        public string Sender { get; set; }

        [Required]
        [StringLength(150)]
        public string Receiver { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Contents { get; set; }

        public DateTime Date { get; set; }
    }
}
