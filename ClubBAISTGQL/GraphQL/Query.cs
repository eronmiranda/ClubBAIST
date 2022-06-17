using System.Linq;
using ClubBAISTGQL.Data;
using ClubBAISTGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace ClubBAISTGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Member> GetMember([Service] AppDbContext context)
        {
            return context.Members;
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<TeeTime> GetTeeTime([Service] AppDbContext context)
        {
            return context.TeeTimes;
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Membership> GetMembership([Service] AppDbContext context)
        {
            return context.Memberships;
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Event> GetEvent([Service] AppDbContext context)
        {
            return context.Events;
        }

        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<StandingTeeTime> GetStandingTeeTime([Service] AppDbContext context)
        {
            return context.StandingTeeTimes;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<MemberTeeTime> GetMemberTeeTime([Service] AppDbContext context)
        {
            return context.MemberTeeTimes;
        }
    }
}