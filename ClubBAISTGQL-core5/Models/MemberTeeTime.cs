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
        public long MemberNumber { get; set; }

        public long? StandingTeeTimeID { get; set; }

        public TeeTime TeeTime { get; set; }

        public Member Member { get; set; }

        public StandingTeeTime StandingTeeTime { get; set; }
    }
}