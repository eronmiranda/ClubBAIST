using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ClubBAISTGQL.Models
{
  public class StandingTeeTime
  {
    [Key]
    public long StandingTeeTimeID { get; set; }

    // Research for DateTime Range
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    // Add this later if needed.
    [Required]
    public TimeSpan RequestedTeeTime { get; set; }

    [Required]
    public DayOfWeek DayOfWeek { get; set; }

    public ICollection<MemberTeeTime> MemberTeeTimes { get; set; }
  }
}