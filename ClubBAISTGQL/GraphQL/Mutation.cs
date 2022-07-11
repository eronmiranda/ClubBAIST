using ClubBAISTGQL.Data;
using ClubBAISTGQL.GraphQL.Events;
using ClubBAISTGQL.GraphQL.Members;
using ClubBAISTGQL.GraphQL.Memberships;
using ClubBAISTGQL.GraphQL.MemberTeeTimes;
using ClubBAISTGQL.GraphQL.RestrictedTimes;
using ClubBAISTGQL.GraphQL.StandingTeeTimes;
using ClubBAISTGQL.GraphQL.TeeTimes;
using ClubBAISTGQL.Models;
using HotChocolate.Subscriptions;

namespace ClubBAISTGQL.GraphQL
{
  public class Mutation
  {
    // Add Membership
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddMembershipPayload> AddMembershipAsync(AddMembershipInput input,
                                                              [ScopedService] AppDbContext context)
    {
      Membership membership = new Membership
      {
        Description = input.Description
      };

      context.Memberships.Add(membership);
      await context.SaveChangesAsync();

      return new AddMembershipPayload(membership);
    }

    // Update Membership
    [UseDbContext(typeof(AppDbContext))]
    public async Task<UpdateMembershipPayload> UpdateMembershipAsync(UpdateMembershipInput input,
                                                                    [ScopedService] AppDbContext context)
    {
      Membership existingMembership = await context.Memberships.FindAsync(input.MembershipID);

      // Update new description for an existing membership.
      existingMembership.Description = input.Description;

      context.Memberships.Update(existingMembership);
      await context.SaveChangesAsync();

      return new UpdateMembershipPayload(existingMembership);
    }

    //Delete Membership.
    [UseDbContext(typeof(AppDbContext))]
    public async Task<DeleteMembershipPayload> DeleteMembershipAsync(DeleteMembershipInput input,
                                                                    [ScopedService] AppDbContext context)
    {
      Membership existingMembership = await context.Memberships.FindAsync(input.MembershipID);

      context.Memberships.Remove(existingMembership);
      await context.SaveChangesAsync();

      return new DeleteMembershipPayload(existingMembership);
    }

    // Add Event
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddEventPayload> AddEventAsync(AddEventInput input,
                                                     [ScopedService] AppDbContext context)
    {
      Event eventObj = new Event
      {
        Description = input.Description
      };

      context.Events.Add(eventObj);
      await context.SaveChangesAsync();

      return new AddEventPayload(eventObj);
    }

    // Update Event
    [UseDbContext(typeof(AppDbContext))]
    public async Task<UpdateEventPayload> UpdateEventAsync(UpdateEventInput input,
                                                           [ScopedService] AppDbContext context)
    {
      Event existingEvent = new Event
      {
        EventID = input.EventID,
        Description = input.Description
      };

      context.Events.Update(existingEvent);
      await context.SaveChangesAsync();

      return new UpdateEventPayload(existingEvent);
    }

    // Delete Event
    [UseDbContext(typeof(AppDbContext))]
    public async Task<DeleteEventPayload> DeleteEventAsync(DeleteEventInput input,
                                                          [ScopedService] AppDbContext context)
    {
      Event existingEvent = await context.Events.FindAsync(input.EventID);

      context.Events.Remove(existingEvent);
      await context.SaveChangesAsync();

      return new DeleteEventPayload(existingEvent);
    }

    // Add RestrictedTime
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddRestrictedTimePayload> AddRestrictedTimeAsync(AddRestrictedTimeInput input,
                                                                       [ScopedService] AppDbContext context)
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

    // Add Member
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddMemberPayload> AddMemberAsync(AddMemberInput input,
                                                       [ScopedService] AppDbContext context)
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

    // Add Tee Time
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddTeeTimePayload> AddTeeTimeAsync(AddTeeTimeInput input,
                                                        [ScopedService] AppDbContext context,
                                                        [Service] ITopicEventSender eventSender,
                                                        CancellationToken cancellationToken)
    {
      TeeTime teeTime = new TeeTime
      {
        DateTeeTime = DateTime.Parse(input.DateTeeTime),
        CartsRequested = input.CartsRequested,
        EventID = input.EventID
      };

      context.TeeTimes.Add(teeTime);
      await context.SaveChangesAsync(cancellationToken);

      await eventSender.SendAsync(nameof(Subscription.OnTeeTimeAdded), teeTime, cancellationToken);

      return new AddTeeTimePayload(teeTime);
    }

    // Add Member-Tee Time relationship.
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddMemberTeeTimePayload> AddMemberTeeTimeAsync(AddMemberTeeTimeInput input,
                                                                     [ScopedService] AppDbContext context)
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

    // Delete Member-Tee Time relationship.
    [UseDbContext(typeof(AppDbContext))]
    public async Task<DeleteMemberTeeTimePayload> DeleteMemberTeeTimeAsync(DeleteMemberTeeTimeInput input,
                                                                           [ScopedService] AppDbContext context)
    {
      MemberTeeTime existingMemberTeeTime = await context.MemberTeeTimes.FindAsync(input.TeeTimeID, input.MemberNumber);

      context.MemberTeeTimes.Remove(existingMemberTeeTime);
      await context.SaveChangesAsync();

      return new DeleteMemberTeeTimePayload(existingMemberTeeTime);
    }

    // Add Standing Tee Time.
    [UseDbContext(typeof(AppDbContext))]
    public async Task<AddStandingTeeTimePayload> AddStandingTeeTimeAsync(AddStandingTeeTimeInput input,
                                                                         [ScopedService] AppDbContext context)
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