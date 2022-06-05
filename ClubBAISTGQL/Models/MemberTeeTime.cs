using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubBAISTGQL.Models
{
    public class MemberTeeTime
    {
        [Required]
        public long TeeTimeID { get; set; }

        [Required]
        public long MembershipNumber { get; set; }

        // Still figuring out if Standing Tee Time should be connected here
        // instead of being connected to TeeTime itself. 
    }
}