using ClubBAISTGQL.Data;
using ClubBAISTGQL.GraphQL.Events;
using ClubBAISTGQL.GraphQL.Memberships;
using ClubBAISTGQL.GraphQL.RestrictedTimes;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL
{
  public class Mutation
  {
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddMembershipPayload> AddMembershipAsync(AddMembershipInput input, [ScopedService] AppDbContext context)
    {
      Membership membership = new Membership
      {
        Description = input.Description
      };

      context.Memberships.Add(membership);
      await context.SaveChangesAsync();

      return new AddMembershipPayload(membership);
    }

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddEventPayload> AddEventAsync(AddEventInput input, [ScopedService] AppDbContext context)
    {
      Event eventObj = new Event
      {
        Description = input.Description
      };

      context.Events.Add(eventObj);
      await context.SaveChangesAsync();

      return new AddEventPayload(eventObj);
    }

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddRestrictedTimePayload> AddRestrictedTimeAsync(AddRestrictedTimeInput input, [ScopedService] AppDbContext context)
    {
      RestrictedTime restrictedTime = new RestrictedTime
      {
        RestrictedDay = input.RestrictedDay,
        RestrictedTimeStart = TimeSpan.Parse(input.RestrictedTimeStart),
        RestrictedTimeEnd = TimeSpan.Parse(input.RestrictedTimeEnd),
        MembershipID = input.MembershipID
      };

      context.RestrictedTimes.Add(restrictedTime);
      await context.SaveChangesAsync();

      return new AddRestrictedTimePayload(restrictedTime);
    }
  }
}