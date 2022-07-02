using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;

namespace ClubBAISTGQL.GraphQL.RestrictedTimes
{
  public class RestrictedTimeType : ObjectType<RestrictedTime>
  {
    protected override void Configure(IObjectTypeDescriptor<RestrictedTime> descriptor)
    {
      descriptor.Description("Represents restricted times to reserve tee times based on Membership levels.");

      descriptor
        .Field(r => r.RestrictedTimeID)
        .Description("Represents the unique ID of a Restricted Time.");

      descriptor
        .Field(r => r.RestrictedDay)
        .Description("Describes the day it is restricted. (i.e. Weekday, Weekend, or Holiday");

      descriptor
        .Field(r => r.RestrictedTimeStart)
        .Description("The start of the restricted time range.");

      descriptor
        .Field(r => r.RestrictedTimeEnd)
        .Description("The end of the restricted time range.");

      descriptor
        .Field(r => r.MembershipID)
        .Description("Represents the unique ID of a Membership.");

      descriptor
        .Field(r => r.Membership)
        .ResolveWith<Resolvers>(r => r.GetMembership(default!, default!))
        .UseDbContext<AppDbContext>()
        .Description("Represents the level of membership that is being describe of time restrictions.");
    }

    private class Resolvers
    {
      public Membership GetMembership([Parent] RestrictedTime restrictedTime, [ScopedService] AppDbContext context)
      {
        return context.Memberships.FirstOrDefault(m => m.MembershipID == restrictedTime.MembershipID);
      }
    }
  }
}