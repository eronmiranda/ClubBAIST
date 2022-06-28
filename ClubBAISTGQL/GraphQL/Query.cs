using System.Linq;
using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace ClubBAISTGQL.GraphQL
{
  [GraphQLDescription("Represents the queries available.")]
  public class Query
  {
    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Membership> GetMembership([ScopedService] AppDbContext context)
    {
      return context.Memberships;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Member> GetMember([ScopedService] AppDbContext context)
    {
      return context.Members;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<TeeTime> GetTeeTime([ScopedService] AppDbContext context)
    {
      return context.TeeTimes;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Event> GetEvent([ScopedService] AppDbContext context)
    {
      return context.Events;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<StandingTeeTime> GetStandingTeeTime([ScopedService] AppDbContext context)
    {
      return context.StandingTeeTimes;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseFiltering]
    [UseSorting]
    public IQueryable<MemberTeeTime> GetMemberTeeTime([ScopedService] AppDbContext context)
    {
      return context.MemberTeeTimes;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<RestrictedTime> GetRestrictedTime([ScopedService] AppDbContext context)
    {
      return context.RestrictedTimes;
    }
  }
}