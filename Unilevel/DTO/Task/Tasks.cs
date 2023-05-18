using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class Tasks
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskStartEnd { get; set; }
        public DateTime CreatedAt { get; set; }
        public string User { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}