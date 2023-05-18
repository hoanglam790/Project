using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class NotifyDTO
    {
        public string Title { get; set; }       
        public int Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}