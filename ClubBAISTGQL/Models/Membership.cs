using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubBAISTGQL.Models
{
    public class Membership
    {
        [Key]
        public long MembershipID { get; set; }

        [Required]
        public string Description { get; set; }

        // Time range to identify the restricted playing time depending on membership level.
        // Gold level membership can play anytime.
        // Silver cannot play between 3:00 pm to 5:30 pm.
        // Bronze cannot play between 3:00pm to 6:00pm.
        // Copper cannot play at all.

        public ICollection<Member> Members { get; set; }

        public ICollection<RestrictedTime> RestrictedTimes { get; set; }
    }
}