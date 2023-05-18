using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Unilevel.DTO
{
    public class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string HyperText { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Creator { get; set; }
    }
}