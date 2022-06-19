using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubBAISTGQL.Models
{
    public class RestrictedTime
    {
        [Key]
        public long RestrictedTimeID { get; set; }
        
        // Current Use Case: Weekday or Weekend.
        public string RestrictedDay { get; set; }

        [Required]
        public TimeSpan RestrictedTimeStart { get; set; }

        [Required]
        public TimeSpan RestrictedTimeEnd { get; set; }

        [Required]
        public long MembershipID { get; set; }

        public Membership Membership { get; set; }
    }
}