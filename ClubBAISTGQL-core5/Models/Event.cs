using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubBAISTGQL.Models
{
    public class Event
    {
        [Key]
        public long EventID { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<TeeTime> TeeTimes { get; set; }
    }
}