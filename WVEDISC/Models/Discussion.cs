using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WVEDISC.Models
{
    public class Discussion
    {
        public int Id { get; set; }
        public ApplicationUser Originator { get; set; }
        public DateTime DateTime { get; set; }
        public String WorkUnit { get; set; }
        public MyDiscussion MyDiscussion { get; set; }

    }

}