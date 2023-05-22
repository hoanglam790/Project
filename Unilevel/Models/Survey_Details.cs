namespace Unilevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Survey_Details
    {
        [Key]
        public int SurveyDetailsID { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string A { get; set; }

        [Required]
        public string B { get; set; }

        [Required]
        public string C { get; set; }

        [Required]
        public string D { get; set; }

        [StringLength(50)]
        public string Result { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? SurveyID { get; set; }

        public int? UserID { get; set; }

        public virtual Survey Survey { get; set; }

        public virtual User User { get; set; }
    }
}
