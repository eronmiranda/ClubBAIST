using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL.Memberships
{
  public class MembershipType : ObjectType<Membership>
  {
    protected override void Configure(IObjectTypeDescriptor<Membership> descriptor)
    {
      descriptor.Description("Represents different types of Membership.");

      descriptor
        .Field(m => m.MembershipID)
        .Description("Represents the unique ID for the Membership.");

      descriptor
          .Field(m => m.Description)
          .Description("Represents the name of the Membership.");

      descriptor
          .Field(m => m.Members)
          .ResolveWith<Resolvers>(m => m.GetMembers(default!, default!))
          .UseDbContext<AppDbContext>()
          .Description("List of members that have subscribed in this membership level.");
    }

    private class Resolvers
    {
      public IQueryable<Member> GetMembers([Parent] Membership membership, [ScopedService] AppDbContext context)
      {
        return context.Members.Where(x => x.MembershipID == membership.MembershipID);
      }
    }
  }
}