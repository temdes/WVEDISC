using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WVEDISC.Models
{
    public class MyDiscussion
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public String Title { get; set; }

        [Required]
        [StringLength(255)]
        public String Detail { get; set; }
        
    }
}