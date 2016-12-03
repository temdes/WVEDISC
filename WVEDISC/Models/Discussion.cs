using System;
using System.ComponentModel.DataAnnotations;

namespace WVEDISC.Models
{
    public class Discussion
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Originator { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(255)]
        public String WorkUnit { get; set; }

        [Required]
        public MyDiscussion MyDiscussion { get; set; }

    }

}