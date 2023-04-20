using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class Notification
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}