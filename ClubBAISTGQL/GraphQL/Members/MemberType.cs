using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL.Members
{
  public class MemberType : ObjectType<Member>
  {
    protected override void Configure(IObjectTypeDescriptor<Member> descriptor)
    {
      descriptor.Description("Represents any golfers that have membership in the club.");

      descriptor
        .Field(m => m.MemberNumber)
        .Description("Represents a unique identifier for a Member.");

      descriptor
        .Field(m => m.FirstName)
        .Description("Represents the first name of a member.");

      descriptor
        .Field(m => m.LastName)
        .Description("Represents the last name of a member.");

      descriptor
        .Field(m => m.Address)
        .Description("Represents the street address (including the city) of where a member resides in.");

      descriptor
        .Field(m => m.PostalCode)
        .Description("Represents the postal code of where a member resides in.");

      descriptor
        .Field(m => m.PhoneNumber)
        .Description("Represents the main contact number of a member.");

      descriptor
        .Field(m => m.AltPhoneNumber)
        .Description("Represents the alternative contact number of a member.");

      descriptor
        .Field(m => m.Email)
        .Description("Represents the email address of a member.");

      descriptor
        .Field(m => m.DateOfBirth)
        .Description("Represents the date of birth of a member.");

      descriptor
        .Field(m => m.Occupation)
        .Description("Represents the occupation of a member.");

      descriptor
        .Field(m => m.CompanyName)
        .Description("Represents the name of the company where a member works for.");

      descriptor
        .Field(m => m.CompanyAddress)
        .Description("Represents the address of the company where a member works at.");

      descriptor
        .Field(m => m.CompanyPostalCode)
        .Description("Represents the postal code of the company where a member works at.");

      descriptor
        .Field(m => m.CompanyPhoneNumber)
        .Description("Represents the contact number of a member's work company.");
      // Missing documentation on each field.

      descriptor
        .Field(m => m.Membership)
        .ResolveWith<Resolvers>(m => m.GetMembership(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("Represents the level of membership the member has.");

      descriptor
        .Field(m => m.MemberTeeTimes)
        .ResolveWith<Resolvers>(m => m.GetMemberTeeTimes(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("List of Member and Tee Time relationships.");
    }

    private class Resolvers
    {
      public Membership GetMembership([Parent] Member member, [ScopedService] AppDbContext context)
      {
        return context.Memberships.FirstOrDefault(m => m.MembershipID == member.MembershipID);
      }

      public IQueryable<MemberTeeTime> GetMemberTeeTimes([Parent] Member member, [ScopedService] AppDbContext context)
      {
        return context.MemberTeeTimes.Where(m => m.MemberNumber == member.MemberNumber);
      }
    }
  }
}