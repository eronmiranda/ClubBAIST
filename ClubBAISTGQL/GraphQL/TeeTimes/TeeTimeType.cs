using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL.TeeTimes
{
  public class TeeTimeType : ObjectType<TeeTime>
  {
    protected override void Configure(IObjectTypeDescriptor<TeeTime> descriptor)
    {
      descriptor.Description("Represents reserved Tee Time for group of members or events.");

      descriptor
        .Field(t => t.TeeTimeID)
        .Description("Represents the unique ID of a Tee Time.");

      descriptor
        .Field(t => t.DateTeeTime)
        .Description("Describes the specific date and time of Tee Time.");

      descriptor
        .Field(t => t.CartsRequested)
        .Description("Specific number of requested carts.");

      descriptor
        .Field(t => t.EventID)
        .Description("Represents the unique ID of Event.");

      descriptor
        .Field(t => t.Event)
        .ResolveWith<Resolvers>(t => t.GetEvent(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("Reserved event for this Tee Time.");

      descriptor
        .Field(t => t.MemberTeeTimes)
        .ResolveWith<Resolvers>(t => t.GetMemberTeeTimes(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("List of Member - Tee Times relationship registered.");
    }

    private class Resolvers
    {
      public Event GetEvent([Parent] TeeTime teeTime, [ScopedService] AppDbContext context)
      {
        return context.Events.FirstOrDefault(e => e.EventID == teeTime.EventID);
      }

      public IQueryable<MemberTeeTime> GetMemberTeeTimes([Parent] TeeTime teeTime, [ScopedService] AppDbContext context)
      {
        return context.MemberTeeTimes.Where(m => m.TeeTimeID == teeTime.TeeTimeID);
      }
    }
  }
}