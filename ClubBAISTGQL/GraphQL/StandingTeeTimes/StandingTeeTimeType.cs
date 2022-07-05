using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL.StandingTeeTimes
{
  public class StandingTeeTimeType : ObjectType<StandingTeeTime>
  {
    protected override void Configure(IObjectTypeDescriptor<StandingTeeTime> descriptor)
    {
      descriptor.Description("Represents any Standing Tee Time requested by a member.");
      descriptor
        .Field(s => s.StandingTeeTimeID)
        .Description("Represents the unique identifier of a Standing Tee Time");

      descriptor
        .Field(s => s.StartDate)
        .Description("The beginning date of the requested Standing Tee Time. yyyy/MM/dd format");

      descriptor
          .Field(s => s.EndDate)
          .Description("The end date of the requested Standing Tee Time. yyyy/MM/dd format");

      descriptor
          .Field(s => s.DayOfWeek)
          .Description("The specific day of the week requested. Accepts integer to determine dayOfWeek.");

      descriptor
        .Field(s => s.MemberTeeTimes)
        .ResolveWith<Resolvers>(s => s.GetMemberTeeTimes(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("List of Member - Tee Time relationship registered.");
    }

    private class Resolvers
    {
      public IQueryable<MemberTeeTime> GetMemberTeeTimes([Parent] StandingTeeTime standingTeeTime, [ScopedService] AppDbContext context)
      {
        return context.MemberTeeTimes.Where(m => m.StandingTeeTimeID == standingTeeTime.StandingTeeTimeID);
      }
    }
  }
}