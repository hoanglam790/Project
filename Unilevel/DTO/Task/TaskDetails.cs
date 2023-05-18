using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class TaskDetails
    {
        public int Status { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int Task { get; set; }
        public int User { get; set; }
    }
}