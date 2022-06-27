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

        public ICollection<Member> Members { get; set; }

        public ICollection<RestrictedTime> RestrictedTimes { get; set; }
    }
}