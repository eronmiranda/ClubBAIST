using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL.Events
{
  public class EventType : ObjectType<Event>
  {
    protected override void Configure(IObjectTypeDescriptor<Event> descriptor)
    {
      descriptor.Description("Represents any events, programs, or holidays.");

      descriptor
        .Field(e => e.EventID)
        .Description("Represents the unique ID of an Event.");

      descriptor
        .Field(e => e.Description)
        .Description("Describes the name of the Event.");

      descriptor
        .Field(t => t.TeeTimes)
        .ResolveWith<Resolvers>(e => e.GetTeeTimes(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("List of tee times reserved for this event");
    }

    private class Resolvers
    {
      public IQueryable<TeeTime> GetTeeTimes([Parent] Event eventObj, [ScopedService] AppDbContext context)
      {
        return context.TeeTimes.Where(t => t.EventID == eventObj.EventID);
      }
    }
  }
}