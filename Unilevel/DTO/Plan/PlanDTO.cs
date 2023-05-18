using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class PlanDTO
    {
        public int PlanID { get; set; }
        public DateTime Calendar { get; set; }
        public int Time { get; set; }
        public string TimeName { get; set; }
        public int Distributor { get; set; }
        public string DistributorName { get; set; }
        public string Purpose { get; set; }
        public string Guest { get; set; }
        public int Status { get; set; }
    }
}