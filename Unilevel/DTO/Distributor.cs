using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class Distributor
    {
        public int Id { get; set; }
        public string DistributorName { get; set; }
        public string DistributorAddress { get; set; }
        public string DistributorEmail { get; set; }
        public string DistributorPhone { get; set; }
    }
}