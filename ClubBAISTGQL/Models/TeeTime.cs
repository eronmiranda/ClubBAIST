using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubBAISTGQL.Models
{
    public class TeeTime
    {
        [Key]
        public long TeeTimeID { get; set; }
        
        [Required]
        public DateTime DateTeeTime { get; set; }

        public int? CartsRequested { get; set; }

        public long? StandingTeeTimeID { get; set; }

        public long? EventID { get; set; }

        public StandingTeeTime StandingTeeTime { get; set; }

        public Event Event { get; set; }

        public ICollection<MemberTeeTime> MemberTeeTimes { get; set; }
    }
}