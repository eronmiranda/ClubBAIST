using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubBAISTGQL.Models
{
  public class Member
  {
    [Key]
    public long MemberNumber { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string PostalCode { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    public string AltPhoneNumber { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Occupation { get; set; }

    [Required]
    public string CompanyName { get; set; }

    [Required]
    public string CompanyAddress { get; set; }

    [Required]
    public string CompanyPostalCode { get; set; }

    [Required]
    public string CompanyPhoneNumber { get; set; }

    // Connects to Membership Class.
    // A Member can only have one Membership.
    // Memberships i.e. Gold, Silver, Bronze, and Copper.
    [Required]
    public long MembershipID { get; set; }

    public Membership Membership { get; set; }

    public ICollection<MemberTeeTime> MemberTeeTimes { get; set; }
  }
}