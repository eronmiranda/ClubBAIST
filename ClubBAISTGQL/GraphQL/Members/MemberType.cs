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
        .Field(m => m.Membership)
        .ResolveWith<Resolvers>(m => m.GetMembership(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("Represents the level of membership the member has.");
    }

    private class Resolvers
    {
      public Membership GetMembership([Parent] Member member, [ScopedService] AppDbContext context)
      {
        return context.Memberships.FirstOrDefault(m => m.MembershipID == member.MembershipID);
      }
    }
  }
}