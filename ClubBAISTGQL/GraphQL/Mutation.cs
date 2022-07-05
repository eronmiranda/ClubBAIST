using ClubBAISTGQL.Data;
using ClubBAISTGQL.GraphQL.Events;
using ClubBAISTGQL.GraphQL.Members;
using ClubBAISTGQL.GraphQL.Memberships;
using ClubBAISTGQL.GraphQL.MemberTeeTimes;
using ClubBAISTGQL.GraphQL.RestrictedTimes;
using ClubBAISTGQL.GraphQL.StandingTeeTimes;
using ClubBAISTGQL.GraphQL.TeeTimes;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL
{
  public class Mutation
  {
    // Add Membership
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

    // Add Event
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

    // Add RestrictedTime
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

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddMemberPayload> AddMemberAsync(AddMemberInput input, [ScopedService] AppDbContext context)
    {
      Member member = new Member
      {
        FirstName = input.FirstName,
        LastName = input.LastName,
        Address = input.Address,
        PostalCode = input.PostalCode,
        PhoneNumber = input.PhoneNumber,
        AltPhoneNumber = String.IsNullOrEmpty(input.AltPhoneNumber) ? null : input.AltPhoneNumber,
        Email = input.Email,
        DateOfBirth = DateTime.Parse(input.DateOfBirth),
        Occupation = input.Occupation,
        CompanyName = input.CompanyName,
        CompanyAddress = input.CompanyAddress,
        CompanyPostalCode = input.CompanyPostalCode,
        CompanyPhoneNumber = input.CompanyPhoneNumber,
        MembershipID = input.MembershipID
      };

      context.Members.Add(member);
      await context.SaveChangesAsync();

      return new AddMemberPayload(member);
    }

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddTeeTimePayload> AddTeeTimeAsync(AddTeeTimeInput input, [ScopedService] AppDbContext context)
    {
      TeeTime teeTime = new TeeTime
      {
        DateTeeTime = DateTime.Parse(input.DateTeeTime),
        CartsRequested = input.CartsRequested,
        EventID = input.EventID
      };

      context.TeeTimes.Add(teeTime);
      await context.SaveChangesAsync();

      return new AddTeeTimePayload(teeTime);
    }

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddMemberTeeTimePayload> AddMemberTeeTimeAsync(AddMemberTeeTimeInput input, [ScopedService] AppDbContext context)
    {
      MemberTeeTime memberTeeTime = new MemberTeeTime
      {
        TeeTimeID = input.TeeTimeID,
        MemberNumber = input.MemberNumber,
        StandingTeeTimeID = input.StandingTeeTimeID
      };

      context.MemberTeeTimes.Add(memberTeeTime);
      await context.SaveChangesAsync();

      return new AddMemberTeeTimePayload(memberTeeTime);
    }

    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddStandingTeeTimePayload> AddStandingTeeTimeAsync(AddStandingTeeTimeInput input, [ScopedService] AppDbContext context)
    {
      StandingTeeTime standingTeeTime = new StandingTeeTime
      {
        StartDate = DateTime.Parse(input.StartDate),
        EndDate = DateTime.Parse(input.EndDate),
        DayOfWeek = (DayOfWeek)input.DayOfWeek,
        RequestedTeeTime = TimeSpan.Parse(input.RequestedTeeTime)
      };

      context.StandingTeeTimes.Add(standingTeeTime);
      await context.SaveChangesAsync();

      return new AddStandingTeeTimePayload(standingTeeTime);
    }
  }
}