using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskTitle { get; set; }
        public string UserTask { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskStartDate { get; set; }
        public DateTime TaskStartEnd { get; set; }
    }
}