using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class PlanDetail
    {
        public int PlanID { get; set; }
        public DateTime Calendar { get; set; }
        public string TimeName { get; set; }
        public string DistributorName { get; set; }
        public string Purpose { get; set; }
        public string Guest { get; set; }
    }
}