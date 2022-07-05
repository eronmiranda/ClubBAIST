using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL.MemberTeeTimes
{
  public class MemberTeeTimeType : ObjectType<MemberTeeTime>
  {
    protected override void Configure(IObjectTypeDescriptor<MemberTeeTime> descriptor)
    {
      descriptor.Description("Represents the relationship between Member and Tee Time. Also includes, Standing Tee Time.");

      descriptor
        .Field(m => m.TeeTime)
        .ResolveWith<Resolvers>(m => m.GetTeeTime(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("Represents the reserved tee time for a member.");

      descriptor
        .Field(m => m.Member)
        .ResolveWith<Resolvers>(m => m.GetMember(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("Represents the member reserved for a tee time.");

      descriptor
        .Field(m => m.StandingTeeTime)
        .ResolveWith<Resolvers>(m => m.GetStandingTeeTime(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("Represents the Standing Tee Time details reserved for this Tee Time and Member.");
    }

    private class Resolvers
    {
      public TeeTime GetTeeTime([Parent] MemberTeeTime memberTeeTime, [ScopedService] AppDbContext context)
      {
        return context.TeeTimes.FirstOrDefault(t => t.TeeTimeID == memberTeeTime.TeeTimeID);
      }

      public StandingTeeTime GetStandingTeeTime([Parent] MemberTeeTime memberTeeTime, [ScopedService] AppDbContext context)
      {
        return context.StandingTeeTimes.FirstOrDefault(s => s.StandingTeeTimeID == memberTeeTime.StandingTeeTimeID);
      }

      public Member GetMember([Parent] MemberTeeTime memberTeeTime, [ScopedService] AppDbContext context)
      {
        return context.Members.FirstOrDefault(m => m.MemberNumber == memberTeeTime.MemberNumber);
      }
    }
  }
}